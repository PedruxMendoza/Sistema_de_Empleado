using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se incluye la librería de entrada / salida
//Para poder utilizar las clases de lectura / escritura
using System.IO;

namespace Tarea3
{
    class Program
    {
        
        static StreamWriter Escribir;
        static StreamReader Leer;
        //Declaramos Variables que estaremos utilizando en el programa 
        public static float[] SalMes = new float[0];//Vector que guardara por mes el salario mensual que inicialmente sera cero
        public static float[] SalMay;//Vector que guardara por mes cual fue el mayor salario semanal
        public static float[] SalSem = new float[4];//Vector que guardara cual fue el salario mayor por semana
        public static String[] NombresMeses;//Vector que iran guardando los nombres de los meses del Mes
        public static float[,] Pago_semanal;//Matriz que guardara el pago semanal de cada mes
        public static int i = 0;//Variable de tipo contador que utilizaremos para crear el codigo del empleado
        public static int k = 0;//Variable de tipo contador que utilizaremos para crear el codigo del edificio
        public static String usernow;//Variable de tipo string donde guardaremos el codigo del empleado al momento de guardar su salario
        //Estructura del Empleado
        struct Empleado
        {
            public String Codigo;
            public String Nombres;
            public String Apellidos;
            public int Edad;
            public String Direccion;
            public int Telefono;
            public String Email;
        }
        //Estructura del Departamento
        struct Departamento
        {
            public String Codigo;
            public String NombreEdificio;
            public int NumEdificio;
            public int NumPisos;
        }
        //Estructura del Salario
        struct Salario
        {
            public String NombreMes;
            public float Pago_semana1;
            public float Pago_semana2;
            public float Pago_semana3;
            public float Pago_semana4;
        }
        //Metodo en el cual iremos agregando los empleados a un archivo de texto
        public static void AgregarEmpleado()
        {
            //Creamos el objeto Empleado de tipo estructura 
            Empleado Persona = new Empleado();
            //Aqui es donde creamos o abrimos el archivo de texto
            Escribir = new StreamWriter("empleado.txt", true);
            k += 1;//Aqui se ira sumando +1 cada vez que iremos creando un nuevo empleado
            string numero = Convert.ToString(k);//Aqui convertimos el numero que es de tipo int a tipo string
            string codigo = ("EM" + numero.PadLeft(3, '0'));//Aqui creamos el codigo del empleado usando el numero que convertimos
            Console.WriteLine("Codigo del Empleado:" + codigo);//Nos mostrara en pantalla el codigo del empleado que se ira creando
            Persona.Codigo = codigo;//Aqui se ira guardando de forma temporal el codigo del empleado dentro de la estructura
            Escribir.WriteLine("Codigo: " + Persona.Codigo);//Aqui se ira escribiendo en el archivo de texto el codigo del empleado creado
            Console.WriteLine("\nDigite los Nombres del Empleado");
            Persona.Nombres = Console.ReadLine();//Aqui se ira guardando el o los nombres de las personas que el mismo programa pedira
            Escribir.WriteLine("Nombres: " + Persona.Nombres);//Y lo ira guardando de un solo en el archivo de texto
            Console.WriteLine("\nDigite los Apellidos del Empleado");
            Persona.Apellidos = Console.ReadLine();//Aqui se ira guardando el o los apellidos de las personas que el mismo programa pedira
            Escribir.WriteLine("Apellidos: " + Persona.Apellidos);//Y lo ira guardando de un solo en el archivo txt
            do
            {//Aqui entraremos en un bucle hasta que el usuario digite una edad no menor o igual que cero y se repetira mientras el usuario
                Console.WriteLine("\nDigite la edad del Empleado");//no digite un numero positivo y menor que 99
                Persona.Edad = int.Parse(Console.ReadLine());//Aqui se ira guardando la edad de la persona que el mismo programa pedira
            } while ((Persona.Edad <= 0) || (Persona.Edad >= 99));//Aqui se ira validando la edad de la o las personas que digitemos
            Escribir.WriteLine("Edad: " + Persona.Edad);//Y si la edad es validad lo escribira en el archivo de texto
            Console.WriteLine("\nDigite la direccion del Empleado");//
            Persona.Direccion = Console.ReadLine();//Aqui se ira guardando la direccion de las personas que el mismo programa pedira
            Escribir.WriteLine("Direccion: " + Persona.Direccion);//Y lo ira guardando de un solo en el archivo de texto
            Console.WriteLine("\nDigite el telefono del Empleado");
            Persona.Telefono = int.Parse(Console.ReadLine());//Aqui se ira guardando el telefono de las personas que el mismo programa pedira
            Escribir.WriteLine("Telefono: " + Persona.Telefono);//Y lo ira guardando de un solo en el archivo de texto
            Console.WriteLine("\nDigite el Correo del Empleado");
            Persona.Email = Console.ReadLine();//Aqui se ira guardando el correo de las personas que el mismo programa pedira
            Escribir.WriteLine("Email: " + Persona.Email);//Y lo ira guardando de un solo en el archivo de texto
            Escribir.WriteLine("-------------------------------------------------------------------");//Y creamos un separador que lo usaremos despues
            Escribir.Close();//Aqui cerramos el proceso de Escribir en el archivo de texto
            Console.WriteLine("\nEmpleado Agregado Correctamente...");//Y al finalizar el proceso creamos un mensaje de que hemos agregado
            Console.ReadLine();//un nuevo empleado en dicho archivo de texto
        }

        public static void AgregarDepartamento()
        {
            //Creamos el objeto Empleado de tipo estructura 
            Departamento Edificio = new Departamento();
            //Aqui es donde creamos o abrimos el archivo de texto
            Escribir = new StreamWriter("departamento.txt", true);
            i += 1;//Aqui se ira sumando +1 cada vez que iremos creando un nuevo edificio
            string numero = Convert.ToString(i);//Aqui convertimos el numero que es de tipo int a tipo string
            string codigo = ("ED" + numero.PadLeft(3, '0'));//Aqui creamos el codigo del edificio usando el numero que convertimos
            Console.WriteLine("Codigo del Edificio:" + codigo);//Nos mostrara en pantalla el codigo del edifcio que se ira creando
            Edificio.Codigo = codigo;////Aqui se ira guardando de forma temporal el codigo del empleado dentro de la estructura
            Escribir.WriteLine("Codigo del edificio: " + Edificio.Codigo);//Aqui se ira escribiendo en el archivo de texto el codigo del empleado creado
            Console.WriteLine("\nDigite el Nombre del Edificio");
            Edificio.NombreEdificio = Console.ReadLine();//Aqui se ira guardando el nombre del departamento que el mismo programa pedira
            Escribir.WriteLine("Nombre de edificio: " + Edificio.NombreEdificio);//Y lo ira guardando de un solo en el archivo de texto
            do
            {//Aqui entraremos en un bucle hasta que el usuario digite una edad no menor o igual que cero y se repetira mientras el usuario
                Console.WriteLine("\nDigite el Numero del Edificio");//no digite un numero positivo
                Edificio.NumEdificio = int.Parse(Console.ReadLine());//Aqui se ira guardando la edad de la persona que el mismo programa pedira
            } while (Edificio.NumEdificio <= 0);//Aqui se ira validando la edad de la o las personas que digitemos
            Escribir.WriteLine("Numero de edificio: " + Edificio.NumEdificio);
            do
            {//Aqui entraremos en un bucle hasta que el usuario digite una edad no menor o igual que cero y se repetira mientras el usuario
                Console.WriteLine("\nDigite Cuantos Pisos tiene el Edificio");//no digite un numero positivo
                Edificio.NumPisos = int.Parse(Console.ReadLine());//Aqui se ira guardando la edad de la persona que el mismo programa pedira
            } while (Edificio.NumPisos <= 0);//Aqui se ira validando la edad de la o las personas que digitemos
            Escribir.WriteLine("Numero de piso: " + Edificio.NumPisos);//Y lo ira guardando de un solo en el archivo de texto
            Escribir.WriteLine("-------------------------------------------------------------------");//Y creamos un separador que lo usaremos despues
            Escribir.Close();//Aqui cerramos el proceso de Escribir en el archivo de texto
            Console.WriteLine("\nDepartamento Agregado Correctamente");//Y al finalizar el proceso creamos un mensaje de que hemos agregado
            Console.ReadLine();//un nuevo departamento en dicho archivo de texto
        }

        public static void AgregarSalario()
        {
            //Creamos el objeto Empleado de tipo estructura 
            Salario Pagos = new Salario();
            int numes;
            Escribir = new StreamWriter("salario.txt", true);
            // La ruta del archivo de texto
            FileStream inFile = new FileStream(@"empleado.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string record;//variable que nos sirva para leer las lineas de texto
            string input;//variable que servira para guardar el codigo del empleado
            int h = 0;//variable que contara las veces que se repite el dato
            Console.Write("Ingrese el codigo del Empleado: ");
            input = Console.ReadLine();// El programa leera el registro y lo muestra en la pantalla
            record = reader.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
            while (record != null)
            {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                {//el contador ira sumando las veces en que se repite el codigo
                    h++;
                }
                record = reader.ReadLine();// y aqui es donde se seguira leyendo todaia las lineas del archivo de texto
            }
            //Despues de que la variable termine de leer cerraremos las conexiones con el documentos
            reader.Close();
            inFile.Close();
            if (h == 0)//Si al terminar de leer el archivo de texto no encuentra ninguna similitud del codigo del empleado
            {//Nos mostrara un mensaje en el que nos avisa que dicho codigo no esta en el archivo de texto
                Console.Write("El Codigo del Empleado ingresado no se encuentra registrado");
                Escribir.Close();//Y cerramos las conexiones con el archivo con el que estamos escribiendo
            }//Pero si al terminar de leer el archivo este es mayor que cero entonces
            else//iremos a buscar dentro del archivo de departamento para comprobar si existes no o el departamento a escribir pero primero decimos
            {// La ruta del archivo de texto
                FileStream inFile2 = new FileStream(@"departamento.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader2 = new StreamReader(inFile2);
                string record2;//variable que nos sirva para leer las lineas de texto
                string input2;//variable que servira para guardar el codigo del empleado
                int e = 0;//variable que contara las veces que se repite el dato
                Console.Write("Ingrese el Codigo del Departamento: ");
                input2 = Console.ReadLine();// El programa leera el registro y lo muestra en la pantalla
                record2 = reader2.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                while (record2 != null)
                {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                    if (record2.Contains(input2))//si encuentra la palabra en dicho archivo entonces
                    {//el contador ira sumando las veces en que se repite el codigo
                        e++;
                    }
                    record2 = reader2.ReadLine();// y aqui es donde se seguira leyendo todaia las lineas del archivo de texto
                }
                //Despues de que la variable termine de leer cerraremos las conexiones con el documentos
                reader2.Close();
                inFile2.Close();
                if (e == 0)//Si al terminar de leer el archivo de texto no encuentra ninguna similitud del codigo del empleado
                {//Nos mostrara un mensaje en el que nos avisa que dicho codigo no esta en el archivo de texto
                    Console.Write("El Codigo del Departamento ingresado no se encuentra registrado");
                    Escribir.Close();//Y cerramos las conexiones con el archivo con el que estamos escribiendo
                }//Pero si al terminar de leer el archivo este es mayor que cero entonces
                else
                {//Se guardara los 2 codigos que se comprobaron con anterioridad y los escribira en el archivo de texto
                    Escribir.WriteLine("Codigo del Empleado: " + input);//Aqui es donde escribe en el archivo de texto el codigo del empleado
                    Escribir.WriteLine("Codigo del Departamento: " + input2);//Aqui es donde escribe en el archivo de texto el codigo del departamento
                    Console.WriteLine("Ingrese la cantidad de meses a pagar");//El programa pedira al usuario la cantidad de meses a pagar
                    numes = int.Parse(Console.ReadLine());//y lo guardara en esta variable dicho valor para despues utilizarlo
                    NombresMeses = new String[numes];//para crear un vector de tipo string donde guardara los nombres de los meses a pagar
                    Pago_semanal = new float[numes, 4];//una matriz donde se guardara el pago semanal de los meses que estara trabajando
                    SalMes = new float[numes];//un vector que guardara el salario total por los meses a trabajar
                    SalMay = new float[numes];//un vector donde guardara el salario mayor en los meses que trabajo
                    usernow = input;//y aqui guardaremos el codigo  del empleado que estamos ingresando actualmente
                    //Despues de guardar y crear lo que necesitaremos comenzamos a ingresar la informacion que realmente utilizaremos
                    for (int f = 0; f < numes; f++)//Para eso entraremos a un contador f que se repetira hasta el numero de meses que estara
                    {//trabajando el empleado
                        float mayor = 0;//Aqui declaramos la variable que guardaremos el numero mayor entre los meses trabajando
                        int i = 0, g = f;//Declaramos 2 variables: 1 para el contador i y otro para obtener el valor del contador f
                        float acumula = 0;//Declaramos un acumulador donde ira sumando el salario semanal
                        Console.Clear();
                        Console.WriteLine("Ingrese el Nombre del Mes " + (f + 1));//Aqui es donde el programa pedira que ingresemo el nombre del mes
                        Pagos.NombreMes = Console.ReadLine();//Y lo guardaremos dentro de la estructura de Pagos
                        NombresMeses[f] = Pagos.NombreMes;//De ahi guardaremos lo que escribimos en el vector donde guardara los nombre del mes
                        Escribir.WriteLine("Nombre del mes: " + NombresMeses[f]);//Y estos meses lo escribiremos en el archivo de texto
                        do
                        {//Aqui entraremos en un bucle hasta que el usuario digite un pago no menor que cero y se repetira mientras el usuario
                            Console.WriteLine("\nIngrese Cuanto fue el pago de la semana 1");//no digite un numero positivo
                            Pagos.Pago_semana1 = float.Parse(Console.ReadLine());//Aqui se ira guardando el pago del empleado que el mismo programa pedira
                        } while (Pagos.Pago_semana1 < 0);//Aqui se ira validando el pago del o los empleado que digitemos
                        Pago_semanal[f, 0] = Pagos.Pago_semana1;//Y lo ira guardando de un solo en la matriz que hemos creado
                        do
                        {//Aqui entraremos en un bucle hasta que el usuario digite un pago no menor que cero y se repetira mientras el usuario
                            Console.WriteLine("\nIngrese Cuanto fue el pago de la semana 2");//no digite un numero positivo
                            Pagos.Pago_semana2 = float.Parse(Console.ReadLine());//Aqui se ira guardando el pago del empleado que el mismo programa pedira
                        } while (Pagos.Pago_semana2 < 0);//Aqui se ira validando el pago del o los empleado que digitemos
                        Pago_semanal[f, 1] = Pagos.Pago_semana2;//Y lo ira guardando de un solo en la matriz que hemos creado
                        do
                        {//Aqui entraremos en un bucle hasta que el usuario digite un pago no menor que cero y se repetira mientras el usuario
                            Console.WriteLine("\nIngrese Cuanto fue el pago de la semana 3");//no digite un numero positivo
                            Pagos.Pago_semana3 = float.Parse(Console.ReadLine());//Aqui se ira guardando el pago del empleado que el mismo programa pedira
                        } while (Pagos.Pago_semana3 < 0);//Aqui se ira validando el pago del o los empleado que digitemos
                        Pago_semanal[f, 2] = Pagos.Pago_semana3;//Y lo ira guardando de un solo en la matriz que hemos creado
                        do
                        {//Aqui entraremos en un bucle hasta que el usuario digite un pago no menor que cero y se repetira mientras el usuario
                            Console.WriteLine("\nIngrese Cuanto fue el pago de la semana 4");//no digite un numero positivo
                            Pagos.Pago_semana4 = float.Parse(Console.ReadLine());//Aqui se ira guardando el pago del empleado que el mismo programa pedira
                        } while (Pagos.Pago_semana4 < 0);//Aqui se ira validando el pago del o los empleado que digitemos
                        Pago_semanal[f, 3] = Pagos.Pago_semana4;//Y lo ira guardando de un solo en la matriz que hemos creado
                        for (i = 0; i < 4; i++)
                        {//Aqui entraremos a un contador i para poder guardar todo los salarios de las 4 semanas que el empleado a ido digitando
                            Escribir.WriteLine("Pago_semana" + (i + 1) + ": $" + Pago_semanal[f, i]);//de un solo en el archivo de texto todo
                            acumula = Pago_semanal[f, i] + acumula;//y tambien sacara el precio mensual por meses con los salario de cada mes
                            if (Pago_semanal[g, i] > mayor)//y aqui comienza a recorrer lo que seria entre columnas de la matriz del pago semanal
                            {//cual de los pagos de la semana que ingreso con anterioridad es el mayor y eso los ira analizando en la condicion
                                mayor = Pago_semanal[g, i];//y si el numero es mayor entonces el nuevo numero mayor sera el mayor de esas 3 semanas
                            }
                        }
                        SalMes[f] = acumula;//En este vector se ira guardando el total de los salarios semanales por mes
                        SalMay[f] = mayor;//En este vector se ira guardando el salario mayor del mes
                        g = 0;//aqui reiniciamos la variable g en cero para que no recorra toda la matriz sino que solo la columna
                    }
                    for (int b = 0; b < 4; b++)//En este contador for lo que haremos sera empezar a recorre primero las filas
                    {//donde creamos otra vez la variable mayor para encontrar el numero mayor pero esta vez entre las semanas
                        float mayor = 0;
                        for (int a = 0; a < numes; a++)
                        {//Este contador lo que hara sera recorrer entre columnas el precio que hay en toda las semanas
                            int c = a;//declaramso una variable c que sera igual al valor del contador de a
                            if (Pago_semanal[c, b] > mayor)
                            {//Mientras este variable recorre entre filas los salarios entre semanas y encuentra un numeor mayor
                                mayor = Pago_semanal[c, b];//este se puede ir guardando dentro de la variable mayor 
                            }
                            SalSem[b] = mayor;//de ahi este numero mayor se guardara dentro del vector de salario entre semanas
                            c = 0;//y reiniciamos la variable c en cero para que no recorra toda la matriz sino que solo la columna
                        }
                    }//Ya despues de escribir y calcular los datos que necesitamos terminamos de escribir el 
                    Escribir.WriteLine("-------------------------------------------------------------------");//Y creamos un separador que lo usaremos despues
                    Escribir.Close();//Aqui cerramos el proceso de Escribir en el archivo de texto
                    Console.WriteLine("\nSalario Agregado Correctamente");//Y al finalizar el proceso creamos un mensaje de que hemos agregado
                }//un nuevo salario de un empleado en dicho archivo de texto
            }
            Console.ReadLine();
        }

        public static void LeerTXT()
        {//En este metodo nos ayudara a mostrar lo que hay dentro de cada txt pero en relacion a una unico empleado
            String Linea;//Variable de tipo string que ayudara a guardar las lineas de texto del documento
            int contador = 0, opl;//Una variable contador que nos ayudara para contar las lineas de texto a imprimir
            do//mientras que la otra servira para elegir las opciones y 
            {//Mientas el usuario no seleccione una de estas opciones no saldra del programa hasta que haya elegido una
                Console.Clear();//de las siguientes opciones de lectura
                Console.WriteLine("\t ****** MENU (LECTURA) ******");
                Console.WriteLine("1. Leer datos del empleado");//Leer el archivo de texto donde estan los empleados
                Console.WriteLine("2. Leer datos del departamento");//Leer el archivo de texto donde estan los departamentos
                Console.WriteLine("3. Leer salario del empleado");//Leer el archivo donde estan los salarios de cada empleado
                Console.WriteLine("\nSeleccione cualquier opcion de lectura:...");
                opl = int.Parse(Console.ReadLine());
                if (opl == 1)
                {// La ruta del archivo de texto   
                    FileStream inFile = new FileStream(@"empleado.txt", FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);
                    string record;//variable que nos sirva para leer las lineas de texto
                    string input;//variable que servira para guardar el texto del empleado
                    int h = 0;//variable que contara las veces que se repite el dato
                    Console.Write("Ingrese el codigo del Empleado: ");
                    input = Console.ReadLine();// El programa leera el registro y lo muestra en la pantalla
                    record = reader.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                    while (record != null)
                    {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                        if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                        {//el contador ira sumando las veces en que se repite el codigo
                            h++;
                        }
                        record = reader.ReadLine();// y aqui es donde se seguira leyendo todaia las lineas del archivo de texto
                    }
                    //Despues de que la variable termine de leer cerraremos las conexiones con el documentos
                    reader.Close();
                    inFile.Close();
                    if (h == 0)//Si al terminar de leer el archivo de texto no encuentra ninguna similitud del codigo del empleado
                    {//Nos mostrara un mensaje en el que nos avisa que dicho codigo no esta en el archivo de texto
                        Console.Write("El Codigo del Empleado ingresado no se encuentra registrado");
                        Console.ReadLine();
                    }
                    else
                    {//Si no es asi hacemos una limpieza de pantalla
                        Console.Clear();
                        Leer = new StreamReader("empleado.txt");
                        record = Leer.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                        while (record != null)
                        {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                            if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                            {//Imprimira la linea donde se encuentra el codigo del empleado que ingresamos
                                Console.WriteLine(record);//Ademas del codigo pondremos un bucle que terminara hasta el separador que hemos puesto
                                while ((Linea = Leer.ReadLine()) != "-------------------------------------------------------------------")
                                {//Para poder imprimir toda la informacion que comienza desde el codigo del empleado hasta el separador que divide
                                    Console.WriteLine(Linea); //la informacion unica de dicho empleado y tambien pondremos un contador que nos ayudara
                                    contador++;//a contar las lineas de codigo que este imprimira hasta llegar al limite que es el separador
                                }
                            }
                            record = Leer.ReadLine();
                        }//Despues de leer y imprimir la informacion del unico empleado 
                        Leer.Close();//cerramos la unica conexion de lectura con el archivo de texto
                        Console.ReadLine();//Y haremos un salto de linea para mostrar la informacion del empleado
                    }
                    break;
                }
                else if (opl == 2)
                {// La ruta del archivo de texto   
                    FileStream inFile = new FileStream(@"departamento.txt", FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);
                    string record;//variable que nos sirva para leer las lineas de texto
                    string input;//variable que servira para guardar el codigo del empleado
                    int h = 0;//variable que contara las veces que se repite el dato
                    Console.Write("Ingrese el codigo del Departamento: ");
                    input = Console.ReadLine();// El programa leera el registro y lo muestra en la pantalla
                    record = reader.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                    while (record != null)
                    {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                        if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                        {//el contador ira sumando las veces en que se repite el codigo
                            h++;
                        }
                        record = reader.ReadLine();// y aqui es donde se seguira leyendo todaia las lineas del archivo de texto
                    }
                    //Despues de que la variable termine de leer cerraremos las conexiones con el documentos
                    reader.Close();
                    inFile.Close();
                    if (h == 0)//Si al terminar de leer el archivo de texto no encuentra ninguna similitud del codigo del departamento
                    {//Nos mostrara un mensaje en el que nos avisa que dicho codigo no esta en el archivo de texto
                        Console.Write("El Codigo del Departamento ingresado no se encuentra registrado");
                        Console.ReadLine();
                    }
                    else
                    {//Si no hacemos una limpieza de pantalla
                        Console.Clear();
                        Leer = new StreamReader("departamento.txt");
                        record = Leer.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                        while (record != null)
                        {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                            if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                            {//Imprimira la linea donde se encuentra el codigo del departamento que ingresamos
                                Console.WriteLine(record);//Ademas del codigo pondremos un bucle que terminara hasta el separador que hemos puesto
                                while ((Linea = Leer.ReadLine()) != "-------------------------------------------------------------------")
                                {//Para poder imprimir toda la informacion que comienza desde el codigo del departamento hasta el separador que divide
                                    Console.WriteLine(Linea);//la informacion unica de dicho departamento y tambien pondremos un contador que nos ayudara
                                    contador++;//a contar las lineas de codigo que este imprimira hasta llegar al limite que es el separador
                                }
                            }
                            record = Leer.ReadLine();
                        }//Despues de leer y imprimir la informacion del unico departamento
                        Leer.Close();//cerramos la unica conexion de lectura con el archivo de texto
                        Console.ReadLine();//Y haremos un salto de linea para mostrar la informacion del departamento
                    }
                    break;
                }
                else if (opl == 3)
                {// La ruta del archivo de texto   
                    FileStream inFile = new FileStream(@"salario.txt", FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);
                    string record;//variable que nos sirva para leer las lineas de texto
                    string input;//variable que servira para guardar el codigo del empleado
                    int h = 0;//variable que contara las veces que se repite el dato
                    Console.Write("Ingrese el codigo del Empleado: ");
                    input = Console.ReadLine();// El programa leera el registro y lo muestra en la pantalla
                    record = reader.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                    while (record != null)
                    {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                        if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                        {//el contador ira sumando las veces en que se repite el codigo
                            h++;
                        }
                        record = reader.ReadLine();// y aqui es donde se seguira leyendo todaia las lineas del archivo de texto
                    }
                    //Despues de que la variable termine de leer cerraremos las conexiones con el documentos
                    reader.Close();
                    inFile.Close();
                    if (h == 0)//Si al terminar de leer el archivo de texto no encuentra ninguna similitud del codigo del empleado
                    {//Nos mostrara un mensaje en el que nos avisa que dicho codigo no esta en el archivo de texto
                        Console.Write("El Codigo del Empleado ingresado no se encuentra registrado");
                        Console.ReadLine();
                    }
                    else
                    {//Si no hacemos una limpieza de pantalla
                        Console.Clear();
                        Leer = new StreamReader("salario.txt");
                        record = Leer.ReadLine();//Aqui es donde se ira guardando la lectura del archivo de texto linea por linea
                        while (record != null)
                        {//Mientras la variable sea diferente de null entoncesn recorrera todo el archivo de texto hasta el momento en que
                            if (record.Contains(input))//si encuentra la palabra en dicho archivo entonces
                            {//Imprimira la linea donde se encuentra el codigo del empleado que ingresamos
                                Console.WriteLine(record);//Ademas del codigo pondremos un bucle que terminara hasta el separador que hemos puesto
                                while ((Linea = Leer.ReadLine()) != "-------------------------------------------------------------------")
                                {//Para poder imprimir toda la informacion que comienza desde el codigo del empleado hasta el separador que divide
                                    Console.WriteLine(Linea);//la informacion unica de dicho empleado y tambien pondremos un contador que nos ayudara
                                    contador++;//a contar las lineas de codigo que este imprimira hasta llegar al limite que es el separador
                                }
                            }
                            record = Leer.ReadLine();
                        }//Despues de leer y imprimir la informacion del unico empleado 
                        Leer.Close();//cerramos la unica conexion de lectura con el archivo de texto
                        Console.ReadLine();//Y haremos un salto de linea para mostrar la informacion del empleado
                    }
                    break;
                }
                else
                {//Y si el no elige algunas de las opciones que estan disponibles pondremos un mensaje que diga que no la eligio
                    Console.WriteLine("\nPor favor, Elija una de las opciones disponibles...");//una de las opciones
                    Console.ReadLine();
                    Console.Clear();//y se hara una limpieza de pantala
                }
            } while ((opl != 1) || (opl != 2) || (opl != 3));//Aqui se ira validando la opcion que el usario ira eligiendo
        }

        public static void CalcularDatos()
        {
            String Linea;//Variable de tipo string que ayudara a guardar las lineas de texto del documento
            int contador = 0;//Una variable contador que nos ayudara para contar las lineas de texto a imprimir
            if (SalMes.Length == 0)//Si al momento de ingresar el vector del salario mensual es de tamaño cero
            {//No podremos calcular los datos porque primero se necesita un empleado valido y luego un salario del mismo empleado
                Console.WriteLine("Lo siento, Primero debe ingresar un empleado y luego un salario para continuar....");
                Console.ReadLine();
            }
            else
            {//Si el salario mensual tiene mas de de cero creamos o abrimos el archivo de texto
                Escribir = new StreamWriter("calculo_salario.txt", true);
                Escribir.WriteLine("Codigo del Empleado: "+ usernow);//Y comenzamos a escribir primero en el archivo de texto el codigo del empleado actual
                for (int e = 0; e < SalMes.Length; e++)//Despues en este contador for comenzaremos a imprimir todo los datos que tenemos guardados
                {//en el vector Salario Mayor que estaba en el mes y tambien cual fue el salario mensual ganado a atraves de la semana
                    Escribir.WriteLine("Salario Mensual del Mes " + (e + 1) + " que fue " + NombresMeses[e] + " es de: : $" + SalMes[e]);
                    Escribir.WriteLine("Pago Mayor del Mes de " + (e + 1) + " que fue " + NombresMeses[e] + " es de: : $" + SalMay[e]);
                }
                for (int d = 0; d < 4; d++)
                {//Despues en el documento comenzamos a escribir cual fue el salario mayor que hubo entre las semanas
                    Escribir.WriteLine("Pago Mayor por las Semanas " + (d + 1) + " : $" + SalSem[d]);
                }//Y despues de escribir todo el documento de texto creamos un separador para cuando se termine de escribir
                Escribir.WriteLine("-------------------------------------------------------------------");
                Escribir.Close();//y luego cerramos todas la conexiones existentes 
                Leer = new StreamReader("calculo_salario.txt");//para luego abrir una en el cual podremos imprimir todo el documento de texto
                while ((Linea = Leer.ReadLine()) != null)// Y
                { //Mientras la variable sea diferente de null entonces recorrera todo el archivo de texto hasta el momento en que
                    Console.WriteLine(Linea);//la variable que se este recorriendo sea null y tambien pondremos un contador que nos ayudara
                    contador++;//a contar las lineas de codigo que este imprimira hasta llegar al limite que es null
                }//Despues de leer y imprimir la informacion
                Leer.Close();//cerramos la unica conexion de lectura con el archivo de texto
                Console.WriteLine("\nCalculo Salaria Efectuado Correctamente");//Y mostramos un mensaje que se efectuo correctamente
                Console.ReadLine();//Y haremos un salto de linea para mostrar la informacion del empleado
            }
        }
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("\t ****** MENU ******");
                Console.WriteLine("1. Agregar datos del empleado");
                Console.WriteLine("2. Agregar datos del departamento");
                Console.WriteLine("3. Agregar salario del empleado");
                Console.WriteLine("4. Mostrar datos");
                Console.WriteLine("5. Calcular datos");
                Console.WriteLine("6. Salir");
                Console.WriteLine("\nSeleccione cualquier opcion:...");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        AgregarEmpleado();
                        break;
                    case 2:
                        Console.Clear();
                        AgregarDepartamento();
                        break;
                    case 3:
                        Console.Clear();
                        AgregarSalario();
                        break;
                    case 4:
                        Console.Clear();
                        LeerTXT();
                        break;
                    case 5:
                        Console.Clear();
                       CalcularDatos();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Gracias por usar nuestro programa. Nos veremos pronto!!!!!!...");
                        break;
                }
            } while (op != 6);
        }
    }
}