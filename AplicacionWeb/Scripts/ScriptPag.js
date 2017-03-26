



$(document).ready(function(){
    
    $('#ingresar').on('click', function(){
        var nombre = bienvenida();
        $('#nombreUsuario').text(nombre);
        $('#dropdownUsuario').show();
        $('#nuevoArticulo').show();
        $('#ingresar').hide();
    })}
    
   )