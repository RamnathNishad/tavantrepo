

using System.Net.Http.Headers;
using System.Text.Json;

namespace MVCAPIClient.Models
{
    public class ApiConsumer
    {
        static string baseUrl = "http://localhost:5005/api/Employees/";
        
        public static List<Employee> GetEmps()
        {
            var login = new LoginModel
            {
                userName = "admin",
                password = "admin123"
            };
            string token = GetToken(login);
            if (token != null)
            {
                var lstEmps = new List<Employee>();
                //call the API GetAll
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);

                    //add the authoriation token
                    http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = http.GetStringAsync("GetAllEmps");
                    response.Wait();
                    if (response.IsCompletedSuccessfully)
                    {
                        var data = response.Result;
                        lstEmps = JsonSerializer.Deserialize<List<Employee>>(data);
                        return lstEmps;
                    }
                    else
                    {
                        throw new Exception(response.Exception.Message);
                    }
                }
            }
            else
            {
                throw new Exception("invalid token");
            }
        }

        public static Employee GetEmpById(int id)
        {
            var emp = new Employee();
            //call the API GetById
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.GetStringAsync($"GetEmpById/{id}");
                response.Wait();
                if (response.IsCompletedSuccessfully)
                {
                    var data = response.Result;
                    emp = JsonSerializer.Deserialize<Employee>(data);
                    return emp;
                }
                else
                {
                    throw new Exception(response.Exception.Message);
                }
            }
        }
        public static string AddEmp(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task=http.PostAsJsonAsync<Employee>("AddEmp", emp);
                task.Wait();

                if(task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if(response.IsSuccessStatusCode)
                    {
                        var responseRead=response.Content.ReadAsStringAsync();
                        responseRead.Wait();
                        var msg = responseRead.Result;
                        return msg;
                    }
                    else
                    {
                        return "could not insert record";
                    }
                }
                else
                {
                    return "Request failed";
                }
            }
        }

        public static bool UpdateEmp(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.PutAsJsonAsync<Employee>($"UpdateEmp/{emp.ecode}", emp);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    { 
                        return false; 
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool DeleteEmployee(int id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.DeleteAsync("DeleteById/"+id.ToString());
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public static string GetToken(LoginModel login)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("http://localhost:5005/api/Account/Login");
                var task = http.PostAsJsonAsync<LoginModel>("", login);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var token = response.Content.ReadAsStringAsync().Result;
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

