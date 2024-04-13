using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Хедерс
//app.Run(async (context) =>
//    { 
//        var response = context.Response;
//        response.Headers.ContentLanguage = "ru-RU";
//        response.Headers.ContentType = "text/plain; charset=utf-8";
//        response.Headers.Append("secret-id", "256");
//        await response.WriteAsync("Привет ASP.Net Core с Headers!");
//    });

//--

// Установка кодов
//app.Run(async (context) =>
//    {
//        context.Response.StatusCode = 404;
//        await context.Response.WriteAsync("Resours not found");
//    });

//--

// htlm
//app.Run(async (context) =>
//{
//    var respose = context.Response;
//    respose.ContentType = "text/html; charset=utf-8";
//    await respose.WriteAsync("<h2>Hello ASP.NET From Metanit </h2>" +
//        "<h3>Я изучаю ASP.NET core </h3>");
//});

//--------------------------------------HttpRequest. Получение данных запроса------------------------------
//Получение заголовков запроса
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach(var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());

//});
//app.Run();

//--

// Получение заголовков
// app.Run(async (context) =>
//{
//      var acceptHeaderValue = context.Request.Headers.Accept; // - получение стандартных заголовок
//      var acceptHeaderValue = context.Request.Headers["accept"]; - вместо "accept" получить любой кастом
//      await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
// });
// app.Run();

//--

// Получение адреса, куда обращается клиент.
//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));
//app.Run();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/plain; charset=utf-8";
//    var path = context.Request.Path;
//    var now = DateTime.Now;
//    var response = context.Response;

//    if (path == "/date")
//        await response.WriteAsync($"Сегодняшняя дата: {now.ToShortDateString()}");
//    else if (path == "/time")
//        await response.WriteAsync($"Время: {now.ToShortTimeString()}");
//    else
//        await response.WriteAsync($"HelloApp!");
//});
//app.Run();

//Строка запроса
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QuaryString: {context.Request.QueryString}</p>");
//});
//app.Run();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append($"<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}<td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});
//app.Run();

//----------------------------------------------Отправка файлов----------------------------------------------

//app.Run(async (context) => await context.Response.SendFileAsync("Панкрат.jpg"));
//app.Run();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html/index.html");
//});
//app.Run();


//---------------------------------------------Работа с формами---------------------------------------------
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        string[] languages = form["languages"];

//        string langList = "";
//        foreach(var lang in languages)
//        {
//            langList += $"{lang}";
//        }


//        await context.Response.WriteAsync($"<div><p>Имя: {name}</p>" +
//            $"<p>Возвраст: {age}</p>" +
//            $"<div>Языки: {langList}</div></div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();

//------------------------------------------------ Редирект ------------------------------------------------

//app.Run(async (context) =>
//{
//    if (context.Request.Path == "/old")
//         context.Response.Redirect("/new");
//    else if (context.Request.Path == "/new")
//        await context.Response.WriteAsync("New Page");
//    else
//        await context.Response.WriteAsync("Main Page");
//});

//app.Run();



//-------------------------------------------------- JSON --------------------------------------------------

//Отправка 
//app.Run(async (context) =>
//{
//    Person ilya = new("Ilya", 21);
//    await context.Response.WriteAsJsonAsync(ilya);
//});
//app.Run();

//public record Person (string name, int age);

//Приёмка через форму.
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;

//    if (request.Path == "/api/user")
//    {
//        var message = "Некорректные данные";

//        try
//        {
//            var person = await request.ReadFromJsonAsync<Person>();
//            if (person != null)
//                message = $"name:{person.name} Age: {person.age}";
//        }
//        catch { }
//        await response.WriteAsJsonAsync(new { text = message });
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html");
//    }
//});
//app.Run();
//public record Person(string name, int age);


List<Person> users = new List<Person>
{
    new() {Id = Guid.NewGuid().ToString(), Name = "Ilya", Age = 21},
    new() {Id = Guid.NewGuid().ToString(), Name = "Anastasia", Age = 21},
    new() {Id = Guid.NewGuid().ToString(), Name = "Denis", Age = 21},
};
app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    //string expressionForNumber = "^/api/users/([0-9]+)$";   // если id представляет число

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method == "GET")
    {
        await GetAllPeople(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // получаем id из адреса url
        string? id = path.Value?.Split("/")[3];
        await GetPerson(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await CreatePerson(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await UpdatePerson(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await DeletePerson(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

// получение всех пользователей
async Task GetAllPeople(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
// получение одного пользователя по id
async Task GetPerson(string? id, HttpResponse response)
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, отправляем его
    if (user != null)
        await response.WriteAsJsonAsync(user);
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
    }
}

async Task DeletePerson(string? id, HttpResponse response)
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // если пользователь найден, удаляем его
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
    }
}

async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            // устанавливаем id для нового пользователя
            user.Id = Guid.NewGuid().ToString();
            // добавляем пользователя в список
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}

async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            // получаем пользователя по id
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            // если пользователь найден, изменяем его данные и отправляем обратно клиенту
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}
public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
