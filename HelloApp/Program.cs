using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// ������
//app.Run(async (context) =>
//    { 
//        var response = context.Response;
//        response.Headers.ContentLanguage = "ru-RU";
//        response.Headers.ContentType = "text/plain; charset=utf-8";
//        response.Headers.Append("secret-id", "256");
//        await response.WriteAsync("������ ASP.Net Core � Headers!");
//    });

//--

// ��������� �����
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
//        "<h3>� ������ ASP.NET core </h3>");
//});

//--------------------------------------HttpRequest. ��������� ������ �������------------------------------
//��������� ���������� �������
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

// ��������� ����������
// app.Run(async (context) =>
//{
//      var acceptHeaderValue = context.Request.Headers.Accept; // - ��������� ����������� ���������
//      var acceptHeaderValue = context.Request.Headers["accept"]; - ������ "accept" �������� ����� ������
//      await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
// });
// app.Run();

//--

// ��������� ������, ���� ���������� ������.
//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));
//app.Run();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/plain; charset=utf-8";
//    var path = context.Request.Path;
//    var now = DateTime.Now;
//    var response = context.Response;

//    if (path == "/date")
//        await response.WriteAsync($"����������� ����: {now.ToShortDateString()}");
//    else if (path == "/time")
//        await response.WriteAsync($"�����: {now.ToShortTimeString()}");
//    else
//        await response.WriteAsync($"HelloApp!");
//});
//app.Run();

//������ �������
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
//    var stringBuilder = new System.Text.StringBuilder("<h3>��������� ������ �������</h3><table>");
//    stringBuilder.Append($"<tr><td>��������</td><td>��������</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}<td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});
//app.Run();

//----------------------------------------------�������� ������----------------------------------------------

//app.Run(async (context) => await context.Response.SendFileAsync("�������.jpg"));
//app.Run();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html/index.html");
//});
//app.Run();


//---------------------------------------------������ � �������---------------------------------------------
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


//        await context.Response.WriteAsync($"<div><p>���: {name}</p>" +
//            $"<p>��������: {age}</p>" +
//            $"<div>�����: {langList}</div></div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

//app.Run();

//------------------------------------------------ �������� ------------------------------------------------

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

//�������� 
//app.Run(async (context) =>
//{
//    Person ilya = new("Ilya", 21);
//    await context.Response.WriteAsJsonAsync(ilya);
//});
//app.Run();

//public record Person (string name, int age);

//������ ����� �����.
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;

//    if (request.Path == "/api/user")
//    {
//        var message = "������������ ������";

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
    //string expressionForNumber = "^/api/users/([0-9]+)$";   // ���� id ������������ �����

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method == "GET")
    {
        await GetAllPeople(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // �������� id �� ������ url
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

// ��������� ���� �������������
async Task GetAllPeople(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
// ��������� ������ ������������ �� id
async Task GetPerson(string? id, HttpResponse response)
{
    // �������� ������������ �� id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // ���� ������������ ������, ���������� ���
    if (user != null)
        await response.WriteAsJsonAsync(user);
    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
    }
}

async Task DeletePerson(string? id, HttpResponse response)
{
    // �������� ������������ �� id
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    // ���� ������������ ������, ������� ���
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
    }
}

async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // �������� ������ ������������
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            // ������������� id ��� ������ ������������
            user.Id = Guid.NewGuid().ToString();
            // ��������� ������������ � ������
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "������������ ������" });
    }
}

async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        // �������� ������ ������������
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            // �������� ������������ �� id
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            // ���� ������������ ������, �������� ��� ������ � ���������� ������� �������
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
            }
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "������������ ������" });
    }
}
public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
