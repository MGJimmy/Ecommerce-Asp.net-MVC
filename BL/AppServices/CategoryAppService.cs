using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Base;
using BL.ViewModels;
using DAL;

namespace BL.AppServices
{
    public class CategoryAppService : BaseAppService
    {
        public IEnumerable<Category> GetAll()
        {
            return TheUnitOfWork.Category.GetAll().ToList();
        }
        public CategoryViewModel GetById(int id)
        {
            Category category = TheUnitOfWork.Category.GetById(id);
            return Mapper.Map<CategoryViewModel>(category);
        }
        public Category GetCateoryById(int id)
        {
            return TheUnitOfWork.Category.GetById(id); 
        }
        public void Insert(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.Category.Insert(category);
            TheUnitOfWork.Commit();
        }
        public bool Update(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool Delete(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public bool CheckExists(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            return TheUnitOfWork.Category.GetAny(c => c.ID == category.ID);
        }

        //public string getname(int id)
        //{
        //    return TheUnitOfWork.Category.getcategoryid(id);
        //}
        //public int getcategory_id_byname(string name)
        //{
        //    return TheUnitOfWork.Category.getcategoryname(name);
        //}
        //public string get_Img_byname(string name)
        //{
        //    return TheUnitOfWork.Category.getcategory_Imgname_byname(name);
        //}
        //public string get_Img_byId(int id)
        //{
        //    return TheUnitOfWork.Category.getcategory_Imgname_byId(id);
        //}

       
        //public Category GetByName(string name)
        //{
        //    return TheUnitOfWork.Category.GetcategoryByName(name);
        //}
    }
}
