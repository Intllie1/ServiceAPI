using Microsoft.EntityFrameworkCore;
using RegistrationAPI.BusinessService.Interfaces;
using RegistrationAPI.DataAccess.Context;
using RegistrationAPI.DataAccess.Models;
using RegistrationAPI.objects;
using RegistrationAPI.objects.Proxies;
using RegistrationAPI.Common;

namespace RegistrationAPI.BusinessService
{
    public class RegistrationService : IRegistration<Registration>
    {
        readonly MySQLDBContext _dbContext;
        public RegistrationService(MySQLDBContext context)
        {
            _dbContext = context;
        }
         ResponseEntity IRegistration<Registration>.AddRegistration(Registration entity)
        {
            ResponseEntity objReg = new ResponseEntity();
            if (GetEmailExists(entity.EmailId))
            {
                _dbContext.Registration.Add(entity);
                _dbContext.SaveChanges();
                objReg.Status = 200;
                objReg.Message = "User Registered Successfully";
                objReg.Data = entity;
                Common.Common.SendMail("Jayesh.Mhatre@Intelliswift.com","Registration", "This is test");
            }
            else
            {
                objReg.Status = 0;
                objReg.Message = "User already Registered";
            }

            return  objReg;
        }

         ResponseEntity IRegistration<Registration>.DeleteRegistration(Registration dbEntity, Registration entity)
        {
            _dbContext.Registration.Remove(entity);
            _dbContext.SaveChanges();
            ResponseEntity objReg = new ResponseEntity();
            objReg.Status = 200;
            objReg.Message = "User Registered Successfully";
            objReg.Data = entity;
            return objReg;
        }

        Registration IRegistration<Registration>.Get(int id)
        {
            return _dbContext.Registration.FirstOrDefault(l => l.ID == id);
        }

        bool GetEmailExists(string emailid)
        {
            Registration regobj = _dbContext.Registration.FirstOrDefault(l => l.EmailId == emailid);
            return regobj==null?true : false;
        }
        IEnumerable<Registration> IRegistration<Registration>.GetAll()
        {
            return (IEnumerable<Registration>)_dbContext.Registration.ToList();
        }
        ResponseEntity IRegistration<Registration>.UpdateRegistration(Registration entity)
        {
            ResponseEntity objReg = new ResponseEntity();
            if (GetEmailExists(entity.EmailId))
            {
                _dbContext.Registration.Update(entity);
                _dbContext.SaveChanges();
                objReg.Status = 200;
                objReg.Message = "User Registered Successfully";
                objReg.Data = entity;
            }
            else
            {
                objReg.Status = 0;
                objReg.Message = "User already Registered";
            }

            return objReg;

        }
    }
}
