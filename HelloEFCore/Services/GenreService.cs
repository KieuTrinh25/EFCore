using HelloEFCore.ViewModel.Request;
using HelloEFCore.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEFCore.Services
{
    public class GenreService
    {
        private readonly AppDB _db;
        public GenreService() 
        { 
            _db = new AppDB();
        }

        /// <summary>
        /// Lay toan bo Genre
        /// </summary>
        /// <returns></returns>
        public List<GenreResponse> GetList()
        {
            var rs = _db.Genres.OrderByDescending(e=>e.Id).Select(e => new GenreResponse
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();
            return rs;
        }
        /// <summary>
        /// Lay Genre theo trang
        /// </summary>
        /// <typeparam name="GenreResponse"></typeparam>
        /// <param name="pageSize">Kich thuoc cua trang</param>
        /// <param name="pageIndex">So thu tu cua trang</param>
        /// <returns>Danh sach Genre theo trang duoc chi dinh</returns>
        //OrderBy: tang dan && OrderByDescending : giam dan 

        public List<GenreResponse> GetList(int pageSize, int pageIndex)
        {
            var rs = _db.Genres.OrderByDescending(e => e.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new GenreResponse
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();
            return rs;
        }

        /// <summary>
        /// Tong so trang cua Genre
        /// </summary> 
        /// <param name="pageSize">Kich thuoc cua trang</param> 
        /// <returns>Danh sach Genre theo trang duoc chi dinh</returns>
        public int PageCount(int pageSize)
        {
            int count = _db.Genres.Count();
            int rs = count / pageSize + ((count % pageSize) > 0 ? 1 : 0);
         // int rs2 = Math.Ceiling(count * 1.0d / pageSize);
            return rs;
        }
        public List<GenreResponse> Filter(String keyWord )
        {
            var rs = _db.Genres.Where(g => g.Name.Contains(keyWord)).Select(g => new GenreResponse
            {
                Id = g.Id,
                Name = g.Name,
            }).ToList();
            return rs;
        }
        public List<GenreResponse> Filter(String keyWord, int pageSize, int pageIndex)
        {
            return null;
        }

        public GenreResponse GetByID(int id)
        {
            return null;
        }
        /// <summary>
        /// Thong ke luong bai viet cua moi Genre theo thang trong nam
        /// </summary>
        /// <param name="month">Thang can thong ke</param>
        /// <param name="year">Nam can thong ke</param>
        /// <returns></returns>
        public List<GenreStatistic> GetStatistic(int month, int year)
        {
            var rs = _db.Genres.Select(g => new GenreStatistic
            {
                Id = g.Id,
                Name = g.Name,
                TotalPost = g.Posts.Where(p => 
                                        p.DateCreated.Month == month && 
                                        p.DateCreated.Year == year ).Count()
            }).ToList();
            return rs;
        }
        /// <summary>
        /// Thong ke het tat ca
        /// </summary>
        /// <param name="genreRequest"></param>
        /// <returns></returns>
        //public List<GenreStatistic> GetStatistic()
        //{
        //    var rs = _db.Genres.Select(e => new GenreStatistic
        //    {
        //        Id = e.Id,
        //        Name = e.Name,
        //        TotalPost = e.Posts.Count()
        //    }).ToList();
        //    return rs;
        //}

        public bool Insert(GenreRequest genreRequest)
        {
            var genre = _db.Genres.FirstOrDefault(e => e.Name == genreRequest.Name);
            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreRequest.Name,
                };
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool Update(GenreRequest genreRequest)
        {
            var genre = _db.Genres.FirstOrDefault(e => e.Id != genreRequest.Id && e.Name == genreRequest.Name);
            if (genre == null)
            {
                genre = _db.Genres.FirstOrDefault(e => e.Id == genreRequest.Id);
                if (genre != null)
                {
                    genre.Name = genreRequest.Name;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }
        public void Delete(int id)
        {
            // co the viet ham delete 1 trong 2 cach duoi
          //  var gen = _db.Genres.FirstOrDefault(e => e.Id == id);//bieu thuc lamda 
            var gen = _db.Genres.Where(e => e.Id == id).FirstOrDefault();
            var lsPost = _db.Posts.Where(e=>e.IdGenre == id).ToList();
            _db.Posts.RemoveRange(lsPost);//xoa het ca ds
            _db.Genres.Remove(gen);// xoa 1 thang
            _db.SaveChanges();
        }
        public bool Delete2(int id)
        {
            var gen = _db.Genres.FirstOrDefault(e => e.Id == id);
            if(gen.Posts.Count() > 0)
            {
                return false;
            }
            _db.Remove(gen);
            _db.SaveChanges();
            return true;
        }


    }
}
