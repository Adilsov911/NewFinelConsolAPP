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
    public class DrugRepository : IRepository<Drug>
    {
        private static int id;
        public Drug Create(Drug entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Druggis.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Drug entity)
        {
            try
            {
                DbContext.Druggis.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
        }

        public Drug Get(Predicate<Drug> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DbContext.Druggis[0];
                }
                else
                {
                    return DbContext.Druggis.Find(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DbContext.Druggis;
                }
                else
                {
                    return DbContext.Druggis.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Update(Drug entity)
        {
            try
            {

                var drug = DbContext.Druggis.Find(g => g.Id == entity.Id);
                if (drug != null)
                {
                    drug.Price = entity.Price;
                    drug.Count = entity.Count;
                    drug.Name = entity.Name;



                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
        }
    }
}
