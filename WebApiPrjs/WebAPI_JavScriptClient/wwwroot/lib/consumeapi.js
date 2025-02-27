function getAllEmps() {
    //send ajax request to web api
    $.ajax({
        url: "http://localhost:5005/api/Employees/GetAllEmps",
        type: "GET",
        //headers: {
        //    "Accept": "application/xml"
        //},        
        success: function (res) {
            console.log(res);

            var str = "<table border=1 width=50%>";
            str += "<tr><th>Ecode</th><th>Ename</th><th>Salary</th><th>Deptid</th></tr>";
            res.forEach(e => {
                str += "<tr>";
                str += "<th>" + e.ecode + "</th>";
                str += "<th>" + e.ename + "</th>";
                str += "<th>" + e.salary + "</th>";
                str += "<th>" + e.deptid + "</th>";
                str += "</tr>";
            });

            $("#d1").html(str);
        },
        error: function (err) {
            alert("failed to call api:"+err.responseText);
        }
    });//closing ajax
}
function getEmpById() {
    let id = $("#txtEc").val();

    $.ajax({
        url: "http://localhost:5005/api/Employees/GetEmpById/" + id,
        type: "GET",
        success: function (res) {
            //console.log(res);
            $("#txtEn").val(res.ename);
            $("#txtSal").val(res.salary);
            $("#txtDid").val(res.deptid);
        },
        error: function (err) {
            alert("failed:"+err.responseText);
        }
    });
}
function addEmp() {
    let empObj = {
        "ecode": $("#txtEc").val(),
        "ename": $("#txtEn").val(),
        "salary": $("#txtSal").val(),
        "deptid": $("#txtDid").val()
    };

    $.ajax({
        url: "http://localhost:5005/api/Employees/AddEmp",
        type: "POST",
        data: JSON.stringify(empObj),
        contentType: "application/json;charset=utf-8",      
        success: function (res) {
            alert(res);
            getAllEmps();
        },
        error: function (err) {
            alert(err.responseText);    
        }
    });
}
function deleteEmpById() {
    let id = $("#txtEc").val();

    $.ajax({
        url: "http://localhost:5005/api/Employees/DeleteById/" + id,
        type: "DELETE",
        success: function (res) {
            //console.log(res);
            //alert("record deleted");
            alert(res);
            getAllEmps();
        },
        error: function (err) {
            alert("failed:" + err.responseText);
        }
    });
}
function updateEmp() { }
