using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel UpdateGenreModel { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(g=>g.Id == GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }
            if(_dbContext.Genres.Any(g=>g.Name.ToLower() == UpdateGenreModel.Name.ToLower() && g.Id != GenreId)){
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut!");
            }
            genre.Name = string.IsNullOrEmpty(UpdateGenreModel.Name.Trim()) ? genre.Name : UpdateGenreModel.Name;
            genre.IsActive = UpdateGenreModel.IsActive;
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}