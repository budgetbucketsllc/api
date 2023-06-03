using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Profile;

namespace BudgetBucketsAPI.Services.EntityServices
{
	public interface IProfileService
	{
		IEnumerable<Entities.Profile> GetAll();
		Entities.Profile GetById(int id);
		Entities.Profile GetProfileByUserId(int userId);
		void Create(CreateRequestProfile model, int userId);
		void Update(int userId, int id, UpdateRequestProfile model);
		void Delete(int id);
	}

    public class ProfileService : IProfileService
    {

        private DataContext _context;
        private readonly IMapper _mapper;

        public ProfileService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateRequestProfile model, int userId)
        {
            if (_context.Profiles.Any(x => x.PhoneNumber == model.PhoneNumber))
                throw new AppException("Profile with the phone number '" + model.PhoneNumber + "' already exists");

            Entities.Profile profile = _mapper.Map<Entities.Profile>(model);
            profile.UserId = userId;
            _context.Profiles.Add(profile);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Entities.Profile profile = getProfile(id);
            _context.Profiles.Remove(profile);

            _context.SaveChanges();
        }

        public IEnumerable<Entities.Profile> GetAll()
        {
            return _context.Profiles;
        }

        public Entities.Profile GetById(int id)
        {
            return getProfile(id);
        }

        public Entities.Profile GetProfileByUserId(int userId)
        {
            return getProfileByUserId(userId);
        }

        public void Update(int userId, int id, UpdateRequestProfile model)
        {
            Entities.Profile profile = getProfile(id);

            if (_context.Profiles.Any(x => x.PhoneNumber == model.PhoneNumber))
                throw new AppException("Profile with the phone number '" + model.PhoneNumber + "' already exists");

            _mapper.Map(model, profile);
            profile.UserId = userId;

            _context.Profiles.Update(profile);

            _context.SaveChanges();
        }

        private Entities.Profile getProfileByUserId(int userId)
        {
            Entities.Profile profile = _context.Profiles.Where(profile => profile.UserId == userId).First();
            if (profile == null) throw new KeyNotFoundException("Profiles not found");
            return profile;
        }

        private Entities.Profile getProfile(int id)
        {
            Entities.Profile? profile = _context.Profiles.Find(id);
            if (profile == null) throw new KeyNotFoundException("Profile not found");
            return profile;
        }

    }
}

