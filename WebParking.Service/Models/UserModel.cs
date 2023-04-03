using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Service.Models
{
    public class UserModel
    {
        [Key]
        //ID пользователя
        public int Id { get; set; }

        //Имя пользователя
        public string Name { get; set; }

        //Логин пользователя
        public string Email { get; set; }

        //Пароль пользователя
        public string Password { get; set; }

        public static implicit operator UserModel(UserEntityModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new UserModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static implicit operator UserEntityModel(UserModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new UserEntityModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static implicit operator UserModel(UserViewModel model)
        {
            if (model == null)
            {

                return null;

            }
           else return new UserModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static implicit operator UserViewModel(UserModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new UserViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}
