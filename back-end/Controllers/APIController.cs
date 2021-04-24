﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Entities.Models;
using WebApi.Models;
using WebApi.Services;
using WebApi.Messages.Requests.users;
using WebApi.Messages.Response.users;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api")]
    public class APIController : ControllerBase
    {
        private IUserService _userService;
        private DB_CloudKitchenContext context;

        public APIController(IUserService userService, DB_CloudKitchenContext db)
        {
            _userService = userService;
            context = db;
        }

        [Route("login")]
        [HttpPost]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            try
            {
                var isExist = context.Customers.FirstOrDefault(f => f.Username == request.Username && f.Password == request.Password); 

                if (isExist != null)
                {
                    return new LoginResponse
                    {
                        LoginStatus = true,
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                return new LoginResponse
                {
                    LoginStatus = false,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        //[Route("users/list")]
        //[HttpPost]
        //public GetAllUsersResponse GetAlUsers([FromBody] GetAlUsersRequest request)
        //{
        //    try
        //    {
        //        var listUsers = context.Users.ToList() ?? new List<User>();
        //        return new GetAllUsersResponse
        //        {
        //            ListUsers = listUsers,
        //            StatusCode = (int)HttpStatusCode.OK
        //        };
        //    }catch(Exception e)
        //    {
        //        return new GetAllUsersResponse
        //        {
        //            ListUsers = null,
        //            StatusCode = (int)HttpStatusCode.BadRequest
        //        };
        //    }
        //}

        [Route("create")]
        [HttpPost]
        public CreateCustomerResponse CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            try
            {
                var newCustomer= new Customer
                {
                    CustomerName = request.customer?.CustomerName ?? "",
                    CustomerEmailId = request.customer?.CustomerEmailId ?? "",
                    CustomerContactPhone = request.customer?.CustomerContactPhone ?? "",
                    Username = request.customer?.Username ?? "",
                    Password = request.customer.Password ?? "",
                    CustomerAddress = request.customer.CustomerAddress ?? ""
                };
                context.Customers.Add(newCustomer);
                context.SaveChanges();
                context.Dispose();
                return new CreateCustomerResponse
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new CreateCustomerResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        [Route("customer/list")]
        [HttpPost]
        public GetListCustomerResponse GetAlUsers()
        {
            try
            {
                var listCustomer = context.Customers.ToList() ?? new List<Customer>();
                return new GetListCustomerResponse
                {
                    ListCustomer = listCustomer,
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new GetListCustomerResponse
                {
                    ListCustomer = null,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        //[Route("users/create")]
        //[HttpPost]
        //public CreateUserResponse CreateUser([FromBody] CreateUserRequest request)
        //{
        //    try
        //    {
        //        var newUser = new User
        //        {
        //            UserId = Guid.NewGuid(),
        //            FirstName = request.user?.FirstName ?? "",
        //            LastName = request.user?.LastName ?? "",
        //            Address = request.user?.LastName ?? "",
        //            City = request.user?.City ?? "",
        //        };

        //        context.Users.Add(newUser);
        //        context.SaveChanges();

        //        return new CreateUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.OK
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new CreateUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.BadRequest
        //        };
        //    }
        //}

        //[Route("users/update")]
        //[HttpPost]
        //public UpdateUserResponse UpdateUser([FromBody] UpdateUserRequest request)
        //{
        //    try
        //    {
        //        var user = context.Users.FirstOrDefault(f => f.UserId == request.user.UserId);

        //        if (user != null)
        //        {
        //            user.FirstName = request.user?.FirstName ?? "";
        //            user.LastName = request.user?.LastName ?? "";
        //            user.Address = request.user?.Address ?? "";
        //            user.City = request.user?.City ?? "";

        //            context.Users.Update(user);
        //            context.SaveChanges();
        //        }

        //        return new UpdateUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.OK
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new UpdateUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.BadRequest
        //        };
        //    }
        //}

        //[Route("users/delete")]
        //[HttpPost]
        //public DeleteUserResponse DeleteUser([FromBody] DeleteUserRequest request)
        //{
        //    try
        //    {
        //        var user = context.Users.FirstOrDefault(f => f.UserId == request.UserId);

        //        if (user != null)
        //        {
        //            context.Users.Remove(user);
        //            context.SaveChanges();
        //        }

        //        return new DeleteUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.OK
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new DeleteUserResponse
        //        {
        //            StatusCode = (int)HttpStatusCode.BadRequest
        //        };
        //    }
        //}

        //[Route("authenticate")]
        //[HttpPost]
        ////[HttpPost("authenticate")]
        //public IActionResult Authenticate(AuthenticateRequest model)
        //{
        //    var response = _userService.Authenticate(model);

        //    Console.WriteLine("Hello World!");

        //    if (response == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(response);
        //}

        ////[Authorize]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        //[HttpGet("persons")]
        //public IActionResult GetAllPerson()
        //{
        //    //var users = _userService.GetAll();
        //    var person = context.Persons.ToList();
        //    return Ok(person);
        //}

        //[HttpPost("persons/getPersonById")]
        //public IActionResult GetPersonById(getPersonByIdParameterModel model)
        //{
        //    //var users = _userService.GetAll();
        //    var person = context.Persons.FirstOrDefault(f => f.Id == model.id);
        //    return Ok(person);
        //}
    }

    public class getPersonByIdParameterModel
    {
        public int id { get; set; }
    }
}
