using BusinenssLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Concreate
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public List<ContactUs> TGetAllList()
        {
            return _contactUsDal.GetAllList();
        }

        public ContactUs TGetByID(int id)
        {
            return _contactUsDal.GetByID(id);
        }

        public List<ContactUs> TGetListByFilter(Expression<Func<ContactUs, bool>> filter)
        {
            return _contactUsDal.GetListByFilter(filter);
        }

        public List<ContactUs> TGetListTRUE()
        {
            return _contactUsDal.GetListTRUE();
        }

        public void TInsert(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void TUpdate(ContactUs entity)
        {
            _contactUsDal.Update(entity);
        }
    }
}
