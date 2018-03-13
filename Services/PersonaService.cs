using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IPersonaService
    {
        List<Persona> GetAll();
        bool Add(Persona model);
        bool Update(Persona model);
        bool Delete(int Personaid);
        Persona Get(int id);
        Persona primero();
    }

    public class PersonaService : IPersonaService
    {
        private readonly ApplicationDbContext _DbContext;

    


        public PersonaService( ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Persona> GetAll()
        {
            var result = new List<Persona>();
            try
            {

                result = _DbContext.personas.ToList();

            }
            catch (Exception)
            {


            }
            return result;
        }

        public Persona Get(int id) // obtener una persona por un id.
        {
            var result = new Persona();
            try
            {

                result = _DbContext.personas.Single(x => x.Id == id);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public bool Add(Persona model)
        {
            try
            {
                _DbContext.Add(model);
                _DbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool Update(Persona model)
        {
            try
            {

                var originalModel = _DbContext.personas.Single(x =>
                    x.Id == model.Id
                    );

                originalModel.username = model.username;
                originalModel.password = model.password;
                originalModel.nombre = model.nombre;
                originalModel.apellidos = model.apellidos;
                originalModel.correo = model.correo;
                originalModel.foto = model.foto;
                originalModel.nacimiento = model.nacimiento;

                originalModel.username = model.username;

                _DbContext.Update(originalModel);
                _DbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool Delete(int categoriaid)
        {
            try
            {
                _DbContext.Entry(new Persona { Id = categoriaid }).State = EntityState.Deleted; ;
                _DbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }


        public Persona primero()
        {
            var result = new Persona();
            try
            {
                 result = _DbContext.personas.FirstOrDefault();
            }
            catch (Exception)
            {

                
            }
            return result;
        }





    }
}
