function setImg(selected_url)
{
    var item = document.getElementById('preview');
    item.src=selected_url;
}
function submitForm(name,tel,planet){
    $.ajax({
        method:"POST",
        url:"/Home/Form",
        data:{Name:name, Tel:tel, Planet:planet}
    }).fail(function(){
        alert("Data transfer error!");
    }).done(function(context){
        alert(context);
    })
}

$(document).ready(function(){
    $('#header').fadeTo(2000,0.3,function(){
        $('html, body').animate({
            scrollTop:$('#content').offset().top},1000
        );
    });
});

$(document).on('submit', 'form', function(){
    var UserName=$('input[name=Name]').val();
    var UserTel=$('input[name=Tel]').val();
    var Planet=$('select').val();
    
    if(UserName.length > 0){
        var regular=/^\8-[0-9]{3}-[0-9]{3}-[0-9]{4}/;
        if(regular.test(UserTel) == true){
            submitForm(UserName,UserTel,Planet);
        }
        else{
            alert("Wrong telephone number!");
        }
        
    }
    else{
        alert('Forgot to type your name!');
    }
      
})