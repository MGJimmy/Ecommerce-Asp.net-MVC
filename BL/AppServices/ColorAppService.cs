using BL.Base;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ColorAppService : BaseAppService
    {
        public IEnumerable<Color> GetAll()
        {
            return TheUnitOfWork.Color.GetAll().ToList();
        }
        public void Insert(ColorViewModel ColorViewModel)
        {
            var color = Mapper.Map<Color>(ColorViewModel);
            TheUnitOfWork.Color.Insert(color);
            TheUnitOfWork.Commit();
        }
        public bool Update(ColorViewModel ColorViewModel)
        {
            var Color = Mapper.Map<Color>(ColorViewModel);
            TheUnitOfWork.Color.Update(Color);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool Delete(int id)
        {
            bool result = false;

            TheUnitOfWork.Color.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckExists(ColorViewModel ColorViewModel)
        {
            var Color = Mapper.Map<Color>(ColorViewModel);
            return TheUnitOfWork.Color.GetAny(c => c.ID == Color.ID);
        }
        public Color GetByID(int id)
        {
            return TheUnitOfWork.Color.GetWhere(c => c.ID == id).FirstOrDefault();
        }

    }
}
