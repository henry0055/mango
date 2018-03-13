using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IMediaService
    {
        List<Media> GetAll();
        bool Add(Media model);
        bool Update(Media model);
        bool Delete(int Mediaid);
        Media Get(int id);
        Media primero();
    }
    

        public class MediaService : IMediaService
        {
            private readonly ApplicationDbContext _DbContext;




            public MediaService(ApplicationDbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public List<Media> GetAll()
            {
                var result = new List<Media>();
                try
                {

                    result = _DbContext.medias.ToList();

                }
                catch (Exception)
                {


                }
                return result;
            }

            public Media Get(int id) // obtener una persona por un id.
            {
                var result = new Media();
                try
                {

                    result = _DbContext.medias.Single(x => x.Id == id);

                }
                catch (Exception)
                {


                }
                return result;
            }
            public bool Add(Media model)
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
            public bool Update(Media model)
            {
                try
                {

                    var originalModel = _DbContext.medias.Single(x =>
                        x.Id == model.Id
                        );

       

                    originalModel.Tipo = model.Tipo;
                    originalModel.Nombre = model.Nombre;
                    originalModel.Duracion = model.Duracion;
                    originalModel.Temporadas = model.Temporadas;
                    originalModel.Estado = model.Estado;
                    originalModel.Imagen = model.Imagen;
                    originalModel.Estreno = model.Estreno;

                   
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


            public Media primero()
            {
                var result = new Media();
                try
                {
                    result = _DbContext.medias.FirstOrDefault();
                }
                catch (Exception)
                {


                }
                return result;
            }



        }

    
}


