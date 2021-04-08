using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;


namespace KostasZaraftisPrtB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = "Data Source=localhost;Initial Catalog = School; Integrated Security= SSPI;";
            SqlConnection conn = new SqlConnection(connectionstring);
            Console.WriteLine("Welcome To Main Apliccation Console");
            Console.WriteLine("Choose please 'Yes' if you  want to Add elements to List Or 'No' if you dont want to Add:");
            Console.WriteLine("Yes/No");
            Console.WriteLine("\n");
            string temp =Console.ReadLine();

            for (int i=0;i<10;i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }

            if (temp == "Yes")
            {
                bool userWantsToExit = false;
                while (!userWantsToExit)
                {
                    Console.WriteLine("Welcome to main menu ...........");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("What do you want to do ?");
                    Console.WriteLine("Please select from option  bellow");

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1.If you want to Add new the Course");
                    Console.WriteLine("2.If you want to Add new Students");
                    Console.WriteLine("3.If you want to Add new Trainers ");
                    Console.WriteLine("4.If you want to Add new Assigment ");
                    Console.WriteLine("5.If you want to see List Of Students");
                    Console.WriteLine("6.If you want to see List Of Courses");
                    Console.WriteLine("7.If you want to see List Of Trainers");
                    Console.WriteLine("8.If you want to see List Of Assigment");
                    Console.WriteLine("9.Put Exit ");
                    Console.WriteLine("-----------------------------------------");
                    string Userchoise = Console.ReadLine();
                    if (Userchoise == "1")

                    {

                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Give please the number of Course you want to Add");
                        int y = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < y; i++)
                        {


                            try
                            {
                                conn.Open();
                                string query = @"INSERT INTO Course
                                (Title,Stream,Type,Start_date,End_date)
                                 values(@title,@stream,@type,@start_date,@end_date)";
                                Console.WriteLine("Input a Title please");
                                string Title = Console.ReadLine();
                                Console.WriteLine("Input a Stream please");
                                string Stream = Console.ReadLine();
                                Console.WriteLine("Input a Type please");
                                string Type = Console.ReadLine();
                                Console.WriteLine("Input a Start_date please");
                                string input = Console.ReadLine();
                                DateTime Start_date;
                                DateTime.TryParse(input, out Start_date);
                                Console.WriteLine("Input a End_date please");
                                string input1 = Console.ReadLine();
                                DateTime End_date;
                                DateTime.TryParse(input1, out End_date);
                                SqlCommand sqlc = new SqlCommand(query, conn);
                                sqlc.Parameters.Add(new SqlParameter("@title", Title));
                                sqlc.Parameters.Add(new SqlParameter("@stream", Stream));
                                sqlc.Parameters.Add(new SqlParameter("@type", Type));
                                sqlc.Parameters.Add(new SqlParameter("@start_date", Start_date));
                                sqlc.Parameters.Add(new SqlParameter("@end_date", End_date));
                                sqlc.ExecuteNonQuery();


                                Course course = new Course(Title, Stream, Type, Start_date, End_date);


                            }
                            catch (Exception x)
                            {
                                Console.WriteLine(x.Message);
                            }
                            finally
                            {
                                if (conn != null)
                                    conn.Close();
                            }

                        }

                    }

                    if (Userchoise == "2")

                    {

                        Console.WriteLine("Give please the number of Student you want to Add");
                        int z = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < z; i++)
                        {
                            try
                            {
                                conn.Open();
                                string query = @"INSERT INTO Student
                                (FirstName,LastName,DateOfBirth,TuitionFees)
                                Values(@FirstName,@LastName,@DateOfBirth,@TuitionFees)";

                                Console.WriteLine("Input the FirstName");
                                string FirstName = Console.ReadLine();
                                Console.WriteLine("Input the LastName");
                                string LastName = Console.ReadLine();
                                Console.WriteLine("Input the Date Of Birth");
                                string input = Console.ReadLine();
                                DateTime DateOfBirth;
                                DateTime.TryParse(input, out DateOfBirth);
                                Console.WriteLine("Input the TuitionsFees");
                                int TuitionFees = Convert.ToInt32(Console.ReadLine());
                                SqlCommand sqlc = new SqlCommand(query, conn);
                                sqlc.Parameters.Add(new SqlParameter("@FirstName",FirstName));
                                sqlc.Parameters.Add(new SqlParameter("@LastName",LastName));
                                sqlc.Parameters.Add(new SqlParameter("@DateofBirth",DateOfBirth));
                                sqlc.Parameters.Add(new SqlParameter(@"TuitionFees",TuitionFees));
                                sqlc.ExecuteNonQuery();
                                
                                    string mqueryString = "select StudentID from Student where FirstName= '" + FirstName + "' AND LastName='" + LastName + "'";
                                    SqlDataAdapter madapter = new SqlDataAdapter(mqueryString,connectionstring);
                                    DataSet UserChoise2 = new DataSet();
                                    madapter.Fill(UserChoise2, "mqueryString1");
                                    int student_id = -1;
                                    foreach (DataRow row in UserChoise2.Tables[0].Rows)
                                    {
                                        student_id = Convert.ToInt32(row["StudentID"].ToString());
                                    }
                                

                                Students student = new Students(FirstName,LastName,DateOfBirth,TuitionFees);



                                Console.WriteLine("In which Course you would like to enroll the Student?");


                                Console.WriteLine(" Please choose from the List Below:");
                                
                                try
                                {
                                    string queryString = "Select * from Course";
                                    SqlDataAdapter adapter1 = new SqlDataAdapter(queryString, connectionstring);
                                    DataSet dtset1 = new DataSet();
                                    adapter1.Fill(dtset1, "Course1");
                                    foreach (DataRow row in dtset1.Tables[0].Rows)
                                    {
                                        Console.WriteLine(row["CourseID"] +"--"+ row["Title"].ToString());
                                    }

                                }
                                   catch (Exception x)
                                   {
                                    Console.WriteLine(x.Message);
                                    }


                                try
                                {
                                   
                                    string query1 = @"Insert into CourseStudent(CourseID,StudentID)
                                                   values(@CourseID,@StudentID)";
                                    int Userchoise1 =Convert.ToInt32 (Console.ReadLine());
                                    SqlCommand sqlc1 = new SqlCommand(query1,conn);
                                    sqlc1.Parameters.Add(new SqlParameter("@CourseID",Userchoise1));
                                    sqlc1.Parameters.Add(new SqlParameter("@StudentID", student_id));
                                    sqlc1.ExecuteNonQuery();

                                }
                                 catch(Exception x)
                                {
                                    Console.WriteLine(x.Message);
                                }
                                finally
                                {
                                    if (conn != null)
                                    {
                                        conn.Close();
                                    }
                                }
                                 


                            }
                            catch (Exception x)
                            {
                                Console.WriteLine(x.Message);

                            }
                            finally
                            {
                                if (conn != null)
                                {
                                    conn.Close();
                                }
                            }

                        }



                    }
                    if (Userchoise == "3")
                    {

                        Console.WriteLine("Give please the  number of Trainers you want to Add");
                        int l = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < l; i++)
                        {
                            try
                            {
                                conn.Open();
                                string query = @"INSERT INTO Trainer(FirstName,LastNmae,Subject)
                                               Values(@FirstName,@LastNmae,@Subject)";
                                Console.WriteLine("Input the FirstName");
                                string FirstName = Console.ReadLine();
                                Console.WriteLine("Input the LastName");
                                string LastName = Console.ReadLine();
                                Console.WriteLine("Input the Subject");
                                string Subject = Console.ReadLine();
                                SqlCommand sqlc = new SqlCommand(query, conn);
                                sqlc.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                                sqlc.Parameters.Add(new SqlParameter("@LastNmae", LastName));
                                sqlc.Parameters.Add(new SqlParameter("@Subject", Subject));
                                sqlc.ExecuteNonQuery();


                                string mqueryString2 = "select TrainerID from Trainer where FirstName= '" + FirstName + "' AND LastNmae='" + LastName + "'";
                                SqlDataAdapter madapter1 = new SqlDataAdapter(mqueryString2, connectionstring);
                                DataSet UserChoise = new DataSet();
                                madapter1.Fill(UserChoise, "mqueryString2");
                                int Trainer_id = -1;
                                foreach (DataRow row in UserChoise.Tables[0].Rows)
                                {
                                    Trainer_id = Convert.ToInt32(row["TrainerID"].ToString());
                                }

                                Trainers trainer = new Trainers(FirstName, LastName, Subject);
                                Console.WriteLine("In which Course you would like to enroll the Trainer?");


                                Console.WriteLine(" Please choose from the List Below:");

                                try
                                {
                                    string queryString = "Select * from Course";
                                    SqlDataAdapter adapter1 = new SqlDataAdapter(queryString, connectionstring);
                                    DataSet dtset1 = new DataSet();
                                    adapter1.Fill(dtset1, "Course1");
                                    foreach (DataRow row in dtset1.Tables[0].Rows)
                                    {
                                        Console.WriteLine(row["CourseID"] + "--" + row["Title"].ToString());
                                    }

                                }
                                catch (Exception x)
                                {
                                    Console.WriteLine(x.Message);
                                }

                                try
                                {

                                    string query1 = @"Insert into CourseTrainer(CourseID,TrainerID)
                                                   values(@CourseID,@TrainerID)";
                                    int Userchoise3 = Convert.ToInt32(Console.ReadLine());
                                    SqlCommand sqlc2 = new SqlCommand(query1, conn);
                                    sqlc2.Parameters.Add(new SqlParameter("@CourseID", Userchoise3));
                                     sqlc2.Parameters.Add(new SqlParameter("@TrainerID", Trainer_id));
                                    sqlc2.ExecuteNonQuery();

                                }
                                catch (Exception x)
                                {
                                    Console.WriteLine(x.Message);
                                }
                                finally
                                {
                                    if (conn != null)
                                    {
                                        conn.Close();
                                    }
                                }




                            }
                            catch (Exception x)

                            {
                                Console.WriteLine(x.Message);
                            }
                            finally
                            {
                                if (conn != null)
                                    conn.Close();
                            }
                        }

                       

                    }

                    if (Userchoise == "4")
                    {

                        Console.WriteLine("Give please the numnber of Assigment you want to Add");

                        int k = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < k; i++)
                        {
                            try
                            {
                                conn.Open();
                                string query = @"INSERT INTO Assigment(Title,desciption,SubDateTime,OralMark,TotalMark)
                                               Values(@Title,@desciption,@SubDateTime,@OralMark,@TotalMark)";
                                Console.WriteLine("Input the Title");
                                string Title = Console.ReadLine();
                                Console.WriteLine("Input Desciption");
                                string Description = Console.ReadLine();
                                Console.WriteLine("Input the SubDateTime");
                                string SubDateTime = Console.ReadLine();
                                Console.WriteLine("Input the OralMark");
                                int OralMark = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Input the TotalMark");
                                int TotalMark = Convert.ToInt32(Console.ReadLine());
                                SqlCommand sqlc = new SqlCommand(query, conn);
                                sqlc.Parameters.Add(new SqlParameter("@Title", Title));
                                sqlc.Parameters.Add(new SqlParameter("@desciption", Description));
                                sqlc.Parameters.Add(new SqlParameter("@SubDateTime", SubDateTime));
                                sqlc.Parameters.Add(new SqlParameter("@OralMark", OralMark));
                                sqlc.Parameters.Add(new SqlParameter("@TotalMark", TotalMark));
                                sqlc.ExecuteNonQuery();



                                string mqueryString2 = "select AssigmentID from Assigment where Title= '" + Title + "' AND desciption='" + Description + "'";
                                SqlDataAdapter madapter1 = new SqlDataAdapter(mqueryString2, connectionstring);
                                DataSet UserChoise = new DataSet();
                                madapter1.Fill(UserChoise, "mqueryString2");
                                int Assigment_id = -1;
                                foreach (DataRow row in UserChoise.Tables[0].Rows)
                                {
                                    Assigment_id = Convert.ToInt32(row["AssigmentID"].ToString());
                                }







                                Assigments assigment = new Assigments(Title,Description,SubDateTime,OralMark,TotalMark);
                                Console.WriteLine("In which Course you would like to give  Assigment?");


                                Console.WriteLine(" Please choose from the List Below:");

                                try
                                {
                                    string queryString = "Select * from Course";
                                    SqlDataAdapter adapter1 = new SqlDataAdapter(queryString, connectionstring);
                                    DataSet dtset1 = new DataSet();
                                    adapter1.Fill(dtset1, "Course1");
                                    foreach (DataRow row in dtset1.Tables[0].Rows)
                                    {
                                        Console.WriteLine(row["CourseID"] + "--" + row["Title"].ToString());
                                    }


                                }
                                catch (Exception x)
                                {
                                    Console.WriteLine(x.Message);
                                }



                                try
                                {

                                    string query1 = @"Insert into CourseAssigment(CourseID,AssigmentID)
                                                   values(@CourseID,@AssigmentID)";
                                    int Userchoise3 = Convert.ToInt32(Console.ReadLine());
                                    SqlCommand sqlc2 = new SqlCommand(query1, conn);
                                    sqlc2.Parameters.Add(new SqlParameter("@CourseID", Userchoise3));
                                    sqlc2.Parameters.Add(new SqlParameter("@AssigmentID", Assigment_id));
                                    sqlc2.ExecuteNonQuery();

                                }
                                catch (Exception x)
                                {
                                    Console.WriteLine(x.Message);
                                }
                                finally
                                {
                                    if (conn != null)
                                    {
                                        conn.Close();
                                    }
                                }

                            }
                            catch (Exception x)
                            {
                                Console.WriteLine(x.Message);
                            }
                            finally
                            {
                                if (conn != null)
                                    conn.Close();
                            }
                        }
                    }

                        if (Userchoise == "5")
                        {
                            Console.WriteLine("Print list of All Students");

                            try
                            {
                                string queryString = "Select * from Student";
                                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionstring);
                                DataSet dtset = new DataSet();
                                adapter.Fill(dtset, "Student1");
                                foreach (DataRow row in dtset.Tables[0].Rows)
                                {
                                    Console.WriteLine(row["FirstName"] + " - - " + row["LastName"].ToString());
                                }

                            }
                            catch (Exception x)
                            {
                                Console.WriteLine(x.Message);
                            }

                        }
                        if (Userchoise == "6")
                        {
                            Console.WriteLine("Print list of All Courses");

                            try
                            {
                                string queryString = "Select * from Course";
                                SqlDataAdapter adapter1 = new SqlDataAdapter(queryString,connectionstring);
                                DataSet dtset1 = new DataSet();
                                adapter1.Fill(dtset1, "Course1");
                                foreach (DataRow row in dtset1.Tables[0].Rows)
                                {
                                    Console.WriteLine(row["Title"].ToString());
                                }

                            }
                            catch (Exception x)
                            {
                                Console.WriteLine(x.Message);
                            }
                         
                        }
                         if (Userchoise == "7")
                          {
                           Console.WriteLine("Print list of All Trainers");

                            try
                            {
                              string queryString = "Select * from Trainer";
                              SqlDataAdapter adapter2 = new SqlDataAdapter(queryString,connectionstring);
                              DataSet dtset2 = new DataSet();
                              adapter2.Fill(dtset2, "Course1");
                              foreach (DataRow row in dtset2.Tables[0].Rows)
                              {
                                Console.WriteLine(row["FirstName"]+"--"+row["LastNmae"].ToString());
                               }

                            }
                              catch (Exception x)
                              {
                              Console.WriteLine(x.Message);
                              }

                         }

                          if (Userchoise == "8")
                          {

                        Console.WriteLine("Print list of All Assigment");

                        try
                        {
                            string queryString = "Select * from Assigment";
                            SqlDataAdapter adapter4 = new SqlDataAdapter(queryString, connectionstring);
                            DataSet dtset4 = new DataSet();
                            adapter4.Fill(dtset4, "Course1");
                            foreach (DataRow row in dtset4.Tables[0].Rows)
                            {
                                Console.WriteLine(row["Title"] + "--" + row["desciption"] + "--" + row["SubDateTime"] + "--" + row["OralMark"] + "--" + row["TotalMark"].ToString());
                            }

                        }
                        catch (Exception x)
                        {
                            Console.WriteLine(x.Message);
                        }






                    }



                    if (Userchoise == "9")
                     {
                        userWantsToExit=true;
                        Console.WriteLine("User decide to exit the  Main menu");
                    }


                }

            }

            if (temp == "No") 
            {
                Console.WriteLine("You can see All the tables");

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Print list of All Trainers");
                Console.WriteLine("-----------------------------------------");
                try
                {
                    string queryString = "Select * from Trainer";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(queryString, connectionstring);
                    DataSet dtset2 = new DataSet();
                    adapter2.Fill(dtset2, "Course1");
                    foreach (DataRow row in dtset2.Tables[0].Rows)
                    {
                        Console.WriteLine(row["FirstName"] + "--" + row["LastNmae"]+"----"+row["Subject"].ToString());
                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }




                Console.WriteLine("-----------------------------------------");


                Console.WriteLine("Print list of All Courses");
                Console.WriteLine("-----------------------------------------");
                try
                {
                    string queryString = "Select * from Course";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(queryString, connectionstring);
                    DataSet dtset1 = new DataSet();
                    adapter1.Fill(dtset1, "Course1");
                    foreach (DataRow row in dtset1.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Title"] + "--" + row["Stream"] + "--" + row["Type"] + row["Start_Date"] + "--" + row["End_Date"].ToString());
                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }


                Console.WriteLine("---------------------------------------------------------------");

                Console.WriteLine("Print list of All Students");
                Console.WriteLine("----------------------------------------------------------------");
                try
                {
                    string queryString = "Select * from Student";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "Student1");
                    foreach (DataRow row in dtset.Tables[0].Rows)
                    {
                        Console.WriteLine(row["FirstName"] + " - - " + row["LastName"] + "--" + row["DateOfBirth"] + " - - - - - " + row["TuitionFees"].ToString());
                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }

                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Print list of All Assigment");

                Console.WriteLine("---------------------------------------------------------------------");
                try
                {
                    string queryString = "Select * from Assigment";
                    SqlDataAdapter adapter4 = new SqlDataAdapter(queryString, connectionstring);
                    DataSet dtset4 = new DataSet();
                    adapter4.Fill(dtset4, "Course1");
                    foreach (DataRow row in dtset4.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Title"] + "--" + row["desciption"] +"--" +row["SubDateTime"] + "--" + row["OralMark"] + "--" + row["TotalMark"].ToString());
                    }

                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }

            }


            Console.ReadKey();
        }
        
        }
    }


               


                




                
                
            
        
    

