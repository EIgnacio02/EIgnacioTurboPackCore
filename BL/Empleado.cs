using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioTurboPackContext context=new DL.EignacioTurboPackContext())
                {
                    var query=context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
                    result.Objects = new List<object>();


                    if (query !=null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono=obj.Telefono;
                            empleado.Status = (bool)obj.Status;
                            result.Objects.Add(empleado);
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }


        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL.EignacioTurboPackContext context = new DL.EignacioTurboPackContext())
                {
                    var query=context.Empleados.FromSqlRaw($"EmpleadoGetBYId {IdEmpleado} ").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Email = query.Email;
                        empleado.Telefono = query.Telefono;

                        result.Object= empleado;
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result =new ML.Result();

            try
            {
                using (DL.EignacioTurboPackContext context = new DL.EignacioTurboPackContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}','{empleado.Email}','{empleado.Telefono}'");
                    result.Objects = new List<object>();

                    if (query>0)
                    {
                        result.Message = "Los datos se ingresaron correctamente";
                    }
                }
                result.Correct=true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result=new ML.Result();

            try
            {
                using (DL.EignacioTurboPackContext context = new DL.EignacioTurboPackContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado}, '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}','{empleado.Email}','{empleado.Telefono}'");
                    result.Objects= new List<object>();

                    if (query>0)
                    {
                        result.Message = "Los datos se actualizaron correctamente";
                    }
                }
                result.Correct=true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioTurboPackContext context = new DL.EignacioTurboPackContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");
                    result.Objects = new List<object>();

                    if (query>0)
                    {
                        result.Message = "Se eliminaron los datos correctamete";
                    }

                }
                result.Correct = true;  
            }
            catch (Exception ex)
            {

            }

            return result;
        }


        public static ML.Result UpdateStatus(int IdEmpleado,bool Status)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioTurboPackContext context= new DL.EignacioTurboPackContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateStatus {IdEmpleado},{Status}");
                    if (query > 0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
                    }
                }
            }
            catch (Exception ex)
            {

            }


            return result;
        }
    }
}