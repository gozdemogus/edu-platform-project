using System;
using AutoMapper;
using BaseIdentity.EntityLayer.Concrete;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTO;
using DTOLayer.DTOs.TodoItemDTOs;

namespace BaseIdentity.PresentationLayer.Mapping.AutoMapperProfile
{
	public class MapProfile:Profile
	{
        //veritabanına kayıt isleri
		public MapProfile()
		{

            //CreateMap<AppUserRegisterDTO, AppUser>();
            //CreateMap<AppUser, AppUserRegisterDTO>();

            //CreateMap<AppUserLoginDTO, AppUser>();
            //CreateMap<AppUser, AppUserLoginDTO>();

            //CreateMap<AddTodoItemDTO, TodoItem>();
            //CreateMap<TodoItem, AddTodoItemDTO>();

            //CreateMap<UpdateTodoItemDTO, TodoItem>();
            //CreateMap<TodoItem, UpdateTodoItemDTO>();

            CreateMap<AddContactDTO, Contact>();
            CreateMap<Contact, AddContactDTO>();

            CreateMap<ListContactDTO, Contact>();
            CreateMap<Contact, ListContactDTO>();

            CreateMap<GetByIdContactDTO, Contact>();
            CreateMap<Contact, GetByIdContactDTO>();
        }
    }
}

