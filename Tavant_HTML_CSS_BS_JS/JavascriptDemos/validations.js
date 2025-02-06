function nameValidation(uname){
 var namePattern = /^[a-zA-Z]{3,10}$/;
 var nameStatus=true;
    if(!namePattern.test(uname)){
        nameStatus=false;
        //display error message
        document.getElementById("nameError").innerHTML="Name should be 3 to 10 characters";
    }
    if(nameStatus==true){
        //make the error invisible
        document.getElementById("nameError").style.visibility="hidden";
    }else{
        //make the error visible
        document.getElementById("nameError").style.visibility="visible";
    }
    
    return nameStatus;
}
function ageValidation(age){
    var agePattern=/^[0-9]{1,3}$/;
    var ageStatus=true;
    if(!agePattern.test(age)){
        ageStatus=false;
        //display error message
        document.getElementById("ageError").innerHTML="Age should be 1 to 3 digits";
    }
    if(ageStatus==true){
        //make the error invisible
        document.getElementById("ageError").style.visibility="hidden";
    }else{
        //make the error visible
        document.getElementById("ageError").style.visibility="visible";
    }
    return ageStatus;
}

function validateForm(){
    var uname=document.getElementById("uname").value;
    var age=document.getElementById("age").value;

    return nameValidation(uname) && ageValidation(age);
}

