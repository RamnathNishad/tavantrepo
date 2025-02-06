function showData(){
    var userName = document.getElementById("txtUserName").value;
    var password = document.getElementById("txtPassword").value;

    var obj = {
        "userName": userName,
        "password": password
    };

    alert(obj.userName);

    var str = JSON.stringify(obj);
    //alert(str.userName); invalid
    document.getElementById("d1").innerHTML = str;
}
function display(){
    var str = '{"userName":"admin","password":"admin"}';
    var obj = JSON.parse(str);
    alert(obj.userName);
}

var users = [];
function addUsers(){
    var userName = document.getElementById("txtUserName").value;
    var password = document.getElementById("txtPassword").value;

    var obj = {
        "userName": userName,
        "password": password
    };

    users.push(obj);
    alert("User added successfully");
    displayUsers();
}
function displayUsers(){
    var str = "";
    var ele="<table border='1'><tr><th>User Name</th><th>Password</th></tr>";
    for(var i=0; i<users.length; i++){
        ele+="<tr><td>"+users[i].userName+"</td><td>"+users[i].password+"</td></tr>";
    }
    ele+="</table>";

    document.getElementById("d1").innerHTML = ele;
}