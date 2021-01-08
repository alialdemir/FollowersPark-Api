using AutoMapper;
using FollowersPark.Models.BlockList;
using FollowersPark.Models.DirectMessage;
using FollowersPark.Models.Log;
using FollowersPark.Models.Pricing;
using FollowersPark.Models.Task;
using FollowersPark.Models.User;
using System;
using System.Linq;

namespace FollowersPark.DataAccess.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, Tables.User>();
            CreateMap<Tables.UserList, UserListModel>();

            CreateMap<UserListModel, Tables.UserList>()
                .ForMember(dest => dest.Usernames, opt => opt.MapFrom(src => string.Join(',', src.Usernames)));

            CreateMap<Tables.UserList, UserListModel>()
                .ForMember(dest => dest.Usernames, opt => opt.MapFrom(src => src.Usernames.Split(',', System.StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<DirectMessageModel, Tables.DirectMessage>()
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => string.Join(',', src.DirectMessages.Select(x => x.Text))));

            CreateMap<Tables.DirectMessage, DirectMessageModel>()
                .ForMember(dest => dest.DirectMessages, opt => opt.MapFrom(src => src.Messages.Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(x => new MessageModel
                {
                    Text = x,
                    DirectMessageId = Guid.NewGuid().ToString()
                })));

            CreateMap<BlockListModel, Tables.BlockList>()
                .ForMember(dest => dest.Usernames, opt => opt.MapFrom(src => string.Join(',', src.Usernames)));

            CreateMap<Tables.BlockList, BlockListModel>()
                .ForMember(dest => dest.Usernames, opt => opt.MapFrom(src => src.Usernames.Split(',', System.StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<LogModel, Tables.Log>();
            CreateMap<Tables.Log, LogModel>();

            CreateMap<TaskModel, Tables.Task>()
                .ForMember(dest => dest.GeoraphicalLocations, opt => opt.MapFrom(src => string.Join(',', src.GeoraphicalLocations)))
                .ForMember(dest => dest.PostsShortCode, opt => opt.MapFrom(src => string.Join(',', src.PostsShortCode)))
                .ForMember(dest => dest.UserList, opt => opt.MapFrom(src => string.Join(',', src.UserList)))
                .ForMember(dest => dest.Hashtags, opt => opt.MapFrom(src => string.Join(',', src.Hashtags)));

            CreateMap<Tables.Task, TaskModel>()
                .ForMember(dest => dest.GeoraphicalLocations, opt => opt.MapFrom(src => src.GeoraphicalLocations.Split(',', System.StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.UserList, opt => opt.MapFrom(src => src.UserList.Split(',', System.StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.Hashtags, opt => opt.MapFrom(src => src.Hashtags.Split(',', System.StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.PostsShortCode, opt => opt.MapFrom(src => src.PostsShortCode.Split(',', System.StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<PricingModel, Tables.Pricing>();
            CreateMap<Tables.Pricing, PricingModel>();
        }
    }
}