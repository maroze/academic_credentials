﻿using Library.Common.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public static byte[] CreateHash(string password)
        {
            byte[] passwordHash;

            passwordHash = new HMACSHA512().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return passwordHash;
        }

        public static implicit operator UserEntityModel(UserModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new UserEntityModel
            {

                Email = model.Email,
                Password = CreateHash(model.Password)
            };
        }
        public static implicit operator UserModel(LoginViewModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new UserModel
            {

                Email = model.Email,
                Password = model.Password
            };
        }
        public static implicit operator UserModel(UserEntityModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new UserModel
            {

                Email = model.Email
            };
        }
    }
}
