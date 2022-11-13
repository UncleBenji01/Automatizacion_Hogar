using System.ComponentModel.Design;
//se inicializan variables globales
string eleccion ;
int opcion;
int temporizador = 2500;
string horario="";
double tempMax=0.0;
double tempMin=0.0;



DateTime hora = DateTime.Now;//Objeto de tipo DateTime que guardará la fecha y hora del sistema
Console.WriteLine("PROYECTO 1");
Console.WriteLine("Elaborado por: ");
Console.WriteLine("Erwin Benjamin Elisua Aldana Monterroso  - 1200922");
Console.WriteLine("Rudy Abraham Morales Salguero - 1018822");
Console.WriteLine("Automatización del hogar");
Console.WriteLine("Presione enter para entrar al menú de opciones");

Console.ReadKey();
Console.Clear();

menu://se muestra el menú
Console.WriteLine("Fecha y hora del dia de hoy: " + hora);//Se muestra fecha y hora actual
Console.WriteLine("\n\nIngrese la opción a la que quiere ingresar");
Console.WriteLine("1. Regular ventilación");
Console.WriteLine("2. Controlar calefacción");
Console.WriteLine("3. Controlar la iluminación");
Console.WriteLine("4. Panel de control"); 
Console.WriteLine("5. Salir");


try
{
    opcion = int.Parse(Console.ReadLine());
    
    switch (opcion)//Se utiliza el switch para evuluar todos los casos posibles
    {
        case 1:
            Console.WriteLine("Haz seleccionado Regular la ventilación. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            string[] arrayHoras = horario.Split(',');//se crea un aray de tipo cadena split con los valores ingresados por el usuario
            if (arrayHoras[0]=="")//se verifica que se hayan ingresado datos, de lo contrario le dirá al usuario que ingrese datos desde el panel de control
            {
                Console.WriteLine("No se ha configurado la ventilación, la puede configurar desde el panel de control.");
                do//ciclo que valida si la opcion es acetable o no
                {
                    Console.WriteLine("¿Desea ir al panel de control? (S/N)");
                    eleccion = Console.ReadLine();
                    if (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N")
                    {
                        Console.WriteLine("Opción no válida, intente de nuevo. Presione enter.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        if (quitarEspacios(ponerMayusculas(eleccion)) == "S")
                        {
                            Console.Clear();
                            goto configuracion;//si elige que si entonces lo llevara al panel de control
                        }
                        else
                        {
                            Console.Clear();
                            goto menu;
                        }
                    }
                } while (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N");
                
            }
            else
            {
                int porcentaje = porcentajeventilacion();
                Console.WriteLine("El nivel de humedad en el aire es del " + porcentaje + "%." +
                    "\n Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear();

                if (porcentaje > 70)
                {
                    Console.WriteLine("El porcentaje de humedad ha excedido el 70%");
                    Console.WriteLine("Programe la ventilación a esta hora para que no se exceda el porcentaje de humedad.");
                    do//ciclo que valida si la opcion es acetable o no
                    {
                        Console.WriteLine("¿Desea encender la ventilación ahora mismo? (S/N)");
                        eleccion = Console.ReadLine();
                        if (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N")
                        {
                            Console.WriteLine("Opción no válida, intente de nuevo. Presione enter.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            if (quitarEspacios(ponerMayusculas(eleccion)) == "S")
                            {
                                Console.WriteLine("Espere un momento para que la ventilación se encienda. No presione ningun botón.");
                                Thread.Sleep(temporizador);

                                Console.WriteLine("Ventilación encindida con éxito. Presione enter para ir al menú.");                                
                                Console.ReadKey();
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.WriteLine("Haz elejido no encender la ventilación encendida con éxito. Presione enter para ir al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                goto menu;
                            }
                        }
                    } while (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N");
                }
                else
                {
                    Console.WriteLine("El nivel de humedad es aceptable. Presione enter para volver al menú.");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu;
                }
            }
            

            break;
        case 2:
            Console.WriteLine("Haz seleccionado Controlar la calefacción. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            if (tempMax == 0.0 && tempMin == 0.0) // si no se ha configurado las temperaturas le pregunta al usuario si quiere configurarlas
            {
                Console.WriteLine("No se ha configurado la calefacción, la puede configurar desde el panel de control.");
                do
                {
                    Console.WriteLine("¿Desea ir al panel de control? (S/N)");
                    eleccion = Console.ReadLine();
                    if (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N")
                    {
                        Console.WriteLine("Opción no válida, intente de nuevo. Presione enter.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        if (quitarEspacios(ponerMayusculas(eleccion)) == "S")
                        {
                            Console.Clear();
                            goto configuracion;
                        }
                        else
                        {
                            Console.Clear();
                            goto menu;
                        }
                    }
                } while (quitarEspacios(ponerMayusculas(eleccion)) != "S" && quitarEspacios(ponerMayusculas(eleccion)) != "N");
            }
            else
            {
                temperaturas(tempMax, tempMin);//se manda a llamar la funcion que realizará todo el control de calefaccion que recibe los parametros de temperaturas maximas y minimas
                goto menu;
            }
            
            break;

            
        case 3:
            Console.WriteLine("Haz seleccionado Controlar la iluminación. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Presione cualquier tecla para ver si hay una persona en la habitación.");
            Console.ReadKey();
            Console.Clear();
           
            Console.WriteLine();
            if (iluminacion()==true)//Si lo que devuelve la funcion es true entonces hay una persona en la habitacion
            {
                Console.WriteLine("Hay una persona en la habitacion.");
               
                do//se crea un ciclo por si la opcion ingresada no es valida
                {
                    Console.WriteLine("¿Desea apagar la luz? (S/N)");
                    eleccion = Console.ReadLine();

                    if (quitarEspacios(ponerMayusculas(eleccion)) != "N" && quitarEspacios(ponerMayusculas(eleccion)) != "S")
                    {
                        Console.WriteLine("Opcion no válida. Presione enter.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        if (quitarEspacios(ponerMayusculas(eleccion)) == "S")
                        {
                            Console.WriteLine("Apangando la luz. Presione enter para ir al menú.");
                            Console.ReadKey();
                            Console.Clear();
                            goto menu;
                        }
                        else
                        {
                            if (quitarEspacios(ponerMayusculas(eleccion)) == "N")
                            {
                                Console.WriteLine("Espere un momento para que la persona se retire de la habitación.");
                                Thread.Sleep(temporizador);
                                
                                Console.WriteLine("La persona ha abandonado la habitación, apangado luces espere un momento.");
                                Thread.Sleep(temporizador - 1500);

                                Console.WriteLine("Luz apagada. Presione enter para ir al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                goto menu;
                            }
                        }
                    }                  
                } while (quitarEspacios(ponerMayusculas(eleccion)) != "N"&& quitarEspacios(ponerMayusculas(eleccion)) != "S");
                

            }
            else
            {
                Console.WriteLine("No hay una persona en la habitacion. Presione enter para ir al menú.");
                Console.ReadKey();
                Console.Clear();
                goto menu;
            }
            break;

        case 4:
            Console.WriteLine("Haz seleccionado Panel de Control. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            configuracion:
            Console.WriteLine("Seleccione una opción:" +
                "\n1. Programar Ventilación." +
                "\n2. Configura temperaturas." +
                "\n3. Mostrar promedio de temperaturas." +
                "\n4. Volver al menu.");

            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Haz Seleccionado programar ventilación. Presione enter.");
                    Console.ReadKey();
                    Console.Clear();                  

                    Console.WriteLine("Ingrese a que horas del día desea que la ventilación se encienda en el formato de 24 hora (horas:minutos) dejando una coma entre cada hora." +
                        "\nEjemplo: 10:30,13:20,18:00 ");
                    Console.WriteLine("Ingrese hora:");

                    horario = Console.ReadLine();

                    Console.WriteLine("Configuración de ventilación exitosa. Presione enter para volver al menú.");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu;

                
                case 2:Console.Clear();//Limpiará todo lo que está en la consola
                    Console.WriteLine("Haz Seleccionado configurar temperaturas. Presione enter.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Ingrese la tempertura máxima deseada.");
                    tempMax = double.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese la tempertura mínima deseada.");
                    tempMin = double.Parse(Console.ReadLine());

                    Console.WriteLine("Configuración de temperaturas exitosa. Presione enter para volver al menú.");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu;


                case 3:
                    Console.WriteLine("Haz Seleccionado ver promedio de temperaturas. Presione enter.");
                    Console.ReadKey();
                    Console.Clear();

                    if (tempMax == 0.0 && tempMin == 0.0) //verifica si ya se configuraron las temperaturas
                    {
                        Console.WriteLine("No se ha configurado las temperaturas máximas y mínimas, la puede configurar desde el panel de control. Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        goto configuracion;
                    }
                    else
                    {
                        Console.WriteLine("El promedio de temperaturas es de " + promediotemperaturas() + " grados.");
                        Console.WriteLine("\nPromedio de temperaturas mostrado con éxito. Presione enter para volver al menú");
                        Console.ReadLine();
                        Console.Clear();
                        goto menu;
                    }
                    

                case 4:
                    Console.WriteLine("Haz Seleccionado volver al menu. Presione enter.");
                    Console.ReadKey();
                    Console.Clear();
                    goto menu;

                default:
                    Console.WriteLine("Opción no válida, vuelva a intentar. Presione enter.");
                    Console.ReadKey();
                    Console.Clear();
                    goto configuracion;                    
            }
            
       

        case 5:
            Console.WriteLine("Haz seleccionado salir. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            return;//terminará todo el programa

        default:Console.WriteLine("Opción no válida. Presione cualquier tecla para volver al menú.");//el default evalua el caso que no sea existente dentro de las opciones
            Console.ReadKey();
            Console.Clear();
            goto menu;
            
    }

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

int porcentajeventilacion()
{
    Random num = new Random();
    int NumeroRandom = num.Next(0, 100);
    return NumeroRandom;
}
double Crearnumeros()//Esta funcion se utilizará para crear un numeros referenciando a las temperaturas
{
    Random num = new Random();
    double NumeroRandom = num.Next(15, 30);
    return NumeroRandom;
}
double promediotemperaturas()//Calcula el promedio de las temperaturas con la funcion de crear numeros
{
    double suma = 0.0;
    for (int i = 0; i < 5; i++)
    {
        suma += Crearnumeros();
    }
    return suma/5;    
}

bool iluminacion()//Se crea una funcion que evalua un numero random y devuelve un booleano 
{
    Random objeto = new Random();//se instancia un objeto que crea un numero random
    int ranNum = objeto.Next(1, 10);//Se coloca los parametros para crear el numero random, en este caso va de 1 a 10
    if (ranNum == 1 || ranNum == 5 || ranNum == 8)
    {
        return true;//Si el numero random es 1, 5 o 8 entonces devuelve true lo cual significa que habrá una persona en la habitacion
    }
    else
    {
        return false;//de lo contrario retorna false que significa que no hay una persona en la habitacion
    }
}

void temperaturas(double temperaturaMaxima, double temperaturaMinima)//Esta funcion realizará todo el proceso para los radiaroes
{
    string opcion;
    Random objeto = new Random();//se instancia un objeto que crea un numero random
    int ranNum = objeto.Next(5, 35);//Se coloca los parametros para crear el numero random, en este caso va de 1 a 10
    if (ranNum < temperaturaMinima) 
    {
        Console.WriteLine("La habitacion está a " + ranNum + " grados. La temperatura mínima configurada es de " + temperaturaMinima + " grados");
        do
        {
            Console.WriteLine("¿Desea encender los radiadores? (S/N) ");
            opcion = Console.ReadLine();
            if (quitarEspacios(ponerMayusculas(opcion)) != "S" && quitarEspacios(ponerMayusculas(opcion)) != "N")//verifica si su respuesta es valida
            {
                Console.WriteLine("Opción no válida, intente de nuevo. Presione enter.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                if (quitarEspacios(ponerMayusculas(opcion)) == "S")
                {
                    Console.WriteLine("Encendiendo radiadores espere un momento.");
                    Thread.Sleep(temporizador);
                    Console.WriteLine("Radiadores encendidos. Presione enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Haz seleccionado no encender los radiadores. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        } while (quitarEspacios(ponerMayusculas(opcion)) != "S" && quitarEspacios(ponerMayusculas(opcion)) != "N");        
    }
    else
    {
        if (ranNum>temperaturaMaxima)
        {
            Console.WriteLine("La habitacion está a " + ranNum + " grados. La temperatura máxima configurada es de " + temperaturaMaxima + " grados");
            do
            {
                Console.WriteLine("¿Desea apagar los radiadores? (S/N) ");
                opcion = Console.ReadLine();
                if (quitarEspacios(ponerMayusculas(opcion)) != "S" && quitarEspacios(ponerMayusculas(opcion)) != "N")
                {
                    Console.WriteLine("Opción no válida, intente de nuevo. Presione enter.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (quitarEspacios(ponerMayusculas(opcion)) == "S")
                    {
                        Console.WriteLine("Apangado radiadores, espere un momento. No presione ningun botón.");
                        Thread.Sleep(temporizador);
                        Console.WriteLine("Radiadores encendidos. Presione enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Haz seleccionado no apagar los radiadores. Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            } while (quitarEspacios(ponerMayusculas(opcion)) != "S" && quitarEspacios(ponerMayusculas(opcion)) != "N");
        }
    }
   
}
string ponerMayusculas(string palabra)//funcion que pone todo el texto en mayusculas
{
    return palabra.ToUpper();
}
string quitarEspacios(string palabra)//funcion que quita los espacios en blaco al principio y fina de la palabra
{
    return palabra.Trim();
}