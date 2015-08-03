$(document).ready(function() {
    $("#link-down-menu").click(function(){
        console.log("botón menú clickado")
        $(".menu ul").slideToggle("easing");
    });
    $("#link-down-buy").click(function(){
        console.log("botón tus pedidos clickado")
        $("#form-acces-user").slideToggle("fast");
    });
    $("#link-down-bussines").click(function(){
        console.log("botón tus pedidos clickado")
        $("#form-acces-bussines").slideToggle("fast");
    });
    $(".close-x").click(function(){
        $("#form-acces-bussines").slideUp("fast");
        $("#form-acces-user").slideUp("fast");
    });
});
