using Core.Entities;
using DataAcces.Context;
using DataAcces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories.Implementations
{
    public class DrugStoreRepository : IRepository<DrugStore>
    {
        private static int id;
        public DrugStore Create(DrugStore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugstores.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(DrugStore entity)
        {
            try
            {
                DbContext.Drugstores.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
        }

        public DrugStore Get(Predicate<DrugStore> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DbContext.Drugstores[0];
                }
                else
                {
                    return DbContext.Drugstores.Find(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<DrugStore> GetAll(Predicate<DrugStore> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DbContext.Drugstores;
                }
                else
                {
                    return DbContext.Drugstores.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Update(DrugStore entity)
        {
            try
            {

                var drugstore = DbContext.Drugstores.Find(g => g.Id == entity.Id);
                if (drugstore != null)
                {
                    drugstore.Name = entity.Name;
                    drugstore.Adress = entity.Adress;
                    drugstore.ContactNumber = entity.ContactNumber;




                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
        }
    }
}
