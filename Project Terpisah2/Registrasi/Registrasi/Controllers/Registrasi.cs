using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace testubes_kpl
{
    public enum RegistrationStatus
    {
        Success,
        Failed,
        UsernameExists,
        PasswordExists
    }

    public class RegistrationClass
    {
        private SimpleDB database;

        public RegistrationClass()
        {
            database = new SimpleDB();
        }

        public RegistrationStatus Register(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RegistrationStatus.Failed;
            }

            if (database.AddMahasiswa(username, password))
            {
                return RegistrationStatus.UsernameExists;
            }

            return database.Registrasi(username, password) == "Success"
                ? RegistrationStatus.Success
                : RegistrationStatus.Failed;
        }
    }

    public class RegistrationController : ApiController
    {
        private RegistrationClass registration;

        public RegistrationController()
        {
            registration = new RegistrationClass();
        }

        [HttpGet]
        public IHttpActionResult Register(string username, string password)
        {
            RegistrationStatus status = registration.Register(username, password);

            switch (status)
            {
                case RegistrationStatus.Success:
                    return Ok("Registration successful");
                case RegistrationStatus.Failed:
                    return BadRequest("Registration failed");
                case RegistrationStatus.UsernameExists:
                    return BadRequest("Username already exists");
                case RegistrationStatus.PasswordExists:
                    return BadRequest("Password already exists");
                default:
                    return BadRequest("Unknown registration status");
            }
        }
    }
}
