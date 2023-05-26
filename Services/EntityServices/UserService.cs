using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Users;

namespace BudgetBucketsAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateRequestUser model);
        void Update(int id, UpdateRequestUser model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Create(CreateRequestUser model)
        {
            // validate
            if (_context.Users.Any(x => x.EmailAddress == model.EmailAddress))
                throw new AppException("User with the email '" + model.EmailAddress + "' already exists");

            // map model to new user object
            User user = _mapper.Map<User>(model);

            user.CreatedAt = DateTime.Now;

            // save user
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }

        public void Update(int id, UpdateRequestUser model)
        {
            User user = getUser(id);

            // validate
            if (model.EmailAddress != user.EmailAddress && _context.Users.Any(x => x.EmailAddress == model.EmailAddress))
                throw new AppException("User with the email '" + model.EmailAddress + "' already exists");

            // copy model to user and save
            _mapper.Map(model, user);

            user.UpdatedAt = DateTime.Now;

            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            User user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }

        // helper methods

        private User getUser(int id)
        {
            User? user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}

