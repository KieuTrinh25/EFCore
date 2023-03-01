// See https://aka.ms/new-console-template for more information
using HelloEFCore;
using HelloEFCore.Services;
//show tat ca ds
//GenreService genreService = new GenreService();
//var listGenre = genreService.GetList();
//Console.WriteLine("Danh sach Genre"); 
//foreach (var genre in listGenre)
//{
//    Console.WriteLine($"Id = {genre.Id}, Name = {genre.Name}");
//}

GenreService genreService = new GenreService();

int pageSize = 5;
int pageIndex = 1;
int pageCount = genreService.PageCount(pageSize);

//phan trang 

for(int i = 1; i <= pageCount; i++)
{
    pageIndex = i;
    var listGenre = genreService.GetList(pageSize, pageIndex);
    Console.WriteLine($"Danh sach Genre trang thu {pageIndex}");
    foreach (var genre in listGenre)
    {
        Console.WriteLine($"Id = {genre.Id}, Name = {genre.Name}");
    }
    Console.WriteLine("-----------------------------------------");
}

