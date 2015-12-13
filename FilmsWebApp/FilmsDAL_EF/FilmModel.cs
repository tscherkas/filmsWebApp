namespace FilmsDAL_EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public interface IFilmModel
    {
        System.Collections.Generic.List<Person> getActorsAsList(int start, int size);
        IQueryable<Person> getActorsIQueryable();
        Person getActor(string ID);
        Person createOrUpdateActor(Person p);
        void deleteActor(string ID);
    }
    public partial class FilmModel : DbContext, IFilmModel
    {
        public FilmModel()
            : base("data source=DOM;initial catalog=movies;integrated security=True;pooling=False;MultipleActiveResultSets=True;App=EntityFramework\" providerName = \"System.Data.SqlClient")
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<KinopoistRelatedMovies> KinopoistRelatedMovies { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieToPerson> MovieToPerson { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Posters> Posters { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.MovieToPerson)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movie)
                .WithMany(e => e.Genre)
                .Map(m => m.ToTable("MovieToGenre").MapLeftKey("GenreId").MapRightKey("MovieId"));

            modelBuilder.Entity<Movie>()
                .Property(e => e.MPAA)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.MovieToPerson)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Posters)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.MovieToPerson)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.user)
                .IsFixedLength();

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.password)
                .IsFixedLength();
        }
        public System.Collections.Generic.List<Person> getActorsAsList(int start, int  size)
        {
                  
            return (from p in Person select p).OrderByDescending(p => p.PersonId).Skip(start).Take(size).ToList();
        }

        List<Person> IFilmModel.getActorsAsList(int start, int size)
        {
            throw new NotImplementedException();
        }
        

        IQueryable<Person> IFilmModel.getActorsIQueryable()
        {
            var ret = (from p in Person select p).OrderByDescending(p => p.PersonId);
            return ret;
        }

        Person IFilmModel.getActor(string ID)
        {
            return Person.Find(ID);        }

        Person IFilmModel.createOrUpdateActor(Person p)
        {
            if(p.PersonId != null)
            {
                Entry(p).State = EntityState.Modified;
                SaveChanges();
            }
            else
            {
                Person.Add(p);
            }
            return p;
        }

        void IFilmModel.deleteActor(string ID)
        {
            if(ID!=null)
            {
                var p = new Person { PersonId = new Guid(ID) };
                Person.Attach(p);
                Person.Remove(p);
                SaveChanges();
            }
        }
    }
}
