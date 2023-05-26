using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Models.Account;
using BudgetBucketsAPI.Models.Users;

namespace BudgetBucketsAPI.Helpers
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequestUser, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequestUser, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            CreateMap<CreateRequestAccount, Account>();

            CreateMap<UpdateRequestAccount, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null type
                        if (x.DestinationMember.Name == "Type" && src.Type == null) return false;

                        return true;
                    }
                ));
        }
    }
}
