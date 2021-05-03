using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        private DBManager dbMan; // A Reference of type DBManager 
                                 // (Initially NULL; NO DBManager Object is created yet)

        public Controller()
        {
            dbMan = new DBManager(); // Create the DBManager Object
        }

//checks the username/password and returns the priviledges associated with this user
        //Returns 0 in case of error

        public int CheckPassword_Basic(string username, string password)
        {
            //Query the DB to check for username/password
            string query = "SELECT priv from Users_basic where username = '" + username + "' and password='" + password + "';";            
            object p = dbMan.ExecuteScalar(query);
            if (p == null) return 0;
            else return (int)p;
        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable SelectCollege()
        {
            string query = "SELECT * FROM COLLEGE;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectCourses()
        {
            string query = "select [Course-ID],[Course Name] from Courses;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectCities()
        {
            string query = "select distinct City from Spots;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectDistricts(string s)
        {
            string query = "select * from Spots Where City='" + s + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectStudentssearch(string s, string s1, string s2, string username, int id)
        {
            // prevent him from searching if the pair has a session that is opened and the student id are located in ssos and opened =1 okay?

            string query = "select s.[Student-ID],username From Student as s,[Courses s] as c Where s.[Student-ID]=c.[Student-ID] aND  c.[Course-ID]= " + s + "  and s.username not in('" + username + "') INTERSECT " +
                "select k.[Student-ID],k.username from Student as k , Spots as c JOIN [S spot Preferred] as b on c.[Spot-ID]=b.[Spot-ID] where  k.[Student-Id] =b.[Student-Id] and c.City='" + s1 + "' and c.District ='" + s2 +
                " 'Except select [Student-ID],username from student where [student-ID] IN (select sid2 from [s request s] where sid1 =" + id + " and [CourseID]=" + s + " union select sid1 from [s request s] where sid2 =" + id + " and [CourseID]=" + s + ")" +
                " Except Select [Student-ID],username from Student where Discovery=0 Except Select [Student-ID],username from Student where Discovery=0 Except (select sid1,username from ssos,Student  where sid1=[student-ID] and sid2= " + id + " and opened=1 and courseid=" + s + " union select sid2,username from ssos,STUDENT  where sid2=[Student-ID] and sid1= " + id + " and opened=1 and courseid=" + s + ");";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectTeacherssearch(string s, string s1, string s2, string username, int id)
        {   // prevent him from searching if courseid and the teacherid and the student id are located in stos and opened =1 okay?
            string query = "select s.[Teacher-ID],username From Teacher as s,[Courses T] as c Where s.[Teacher-ID]=c.[Teacher-ID] aND  c.[Course-ID]= " + s + "   INTERSECT " +
                "select k.[Teacher-ID],k.username from Teacher as k , Spots as c JOIN [t spot Preferred] as b on c.[Spot-ID]=b.[Spot-ID] where  k.[Teacher-Id] =b.[Teacher-Id] and c.City='" + s1 + "' and c.District ='" + s2 +
                "'Except select c.[Teacher-ID],a.username from Teacher as a,Student as b,[S request T] as c where a.[Teacher-ID]=c.[Teacher-ID] and b.[Student-ID]=c.[Student-ID] and b.username='" + username + "' and courseid=" + s +
                " Except Select [Teacher-ID],username from Teacher where Discovery=0 except (select teacherid,username from Teacher,Stos where teacherid=[Teacher-ID] and courseid=" + s + " and  studentid=" + id + " and opened=1);";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectFaculty(string s)
        {
            string query = "select [Faculty name],[Faculty id],[College-ID] from facultynames,Faculty where facultynames.[Faculty id]=Faculty.[Faculty-ID] and [College-ID] = " + s + " ;";
            return dbMan.ExecuteReader(query);
        }
        
         
        public DataTable SelectDepartment(string s, string s2)
        {
            string query = "SELECT [Department-ID],[Department Name] FROM Department Where [Faculty-ID] ="+ s+ "and [College-ID]= " + s2 + ";";
            return dbMan.ExecuteReader(query);
        }

  
        ////////////////////////// KEFAHHHHHHHHH///////////////////////////
         // getting the department for continuing registration

        public bool isusernamehere(string username)
        {
        string query="select count(*) from users_basic where username='"+username+"';";
               int x= (int)dbMan.ExecuteScalar(query);
              if(x==0)
               {
                return false;   // the username is not  here
               }

              return true; 
        }

        // a function to insert into userbasic values
     public int insertintouserbasic(string username,string password,int priv)
        {

           string query=  "insert into users_basic(username,password,Priv) values ('" +username+"',"+password+","+priv+");";
            return dbMan.ExecuteNonQuery(query);


        }

     public int insertintostudent(string email,string Fname, string Lname, int age,string gender,string phone,string city,string district,int departmentid,int collegeid,int facultyid,string username)
     {

         string query = "insert into Student(email,[First name],[Last Name],Age,Gender,Phone#,City,District,[Department-ID],[College-ID],[Faculty-ID],username) values('"
            +email+"','"+ Fname + "','"+ Lname+"',"  +age+",'"+gender+
             "','"+phone+"','"+city+"','"+district+"',"+departmentid+","+collegeid+","+facultyid+",'"+username+"');";


         return dbMan.ExecuteNonQuery(query);


     }
     public int insertintoteacher(string email ,int priceperhour,string Fname, string Lname, int age, string gender, string phone, string city, string district, int departmentid, int collegeid, int facultyid, string username)
     {

         string query = "insert into Teacher(priceperhour,email,[First name],[Last Name],Age,Gender,Phone#,City,District,[Department-ID],[College-ID],[Faculty-ID],username) values("+
           priceperhour+",'" + email + "','" + Fname + "','" + Lname + "'," + age + ",'" + gender +
             "','" + phone + "','" + city + "','" + district + "'," + departmentid + "," + collegeid + "," + facultyid + ",'" + username + "');";


         return dbMan.ExecuteNonQuery(query);


     }




        
        public DataTable selectdepartment(int facultyid,int collegeid)
        {
            string query="select Department.[Department-ID], [Department Name]  from Department where [College-ID]="+collegeid +"and [Faculty-ID]="+facultyid+";";
            return dbMan.ExecuteReader(query);
        }
        // getting the id depeding on ur priv if priv=2 then returing the teacher id corrosponding to this username
        public int getidfromuserandpriv(string username, int priv)
        {
            if (priv == 2)
            {
                string query = "Select [Teacher-ID] from teacher where teacher.username='" + username + "';";
                return (int)dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {

                string query = "Select [Student-ID] from student where student.username='" + username + "';";
                return (int)dbMan.ExecuteScalar(query);

            }
            return 0;
        }
        // retriving the courses name and id that a student is requesting the other teacher used for accept,decline
        public DataTable selectcoursenamebyidfromsrt(int sid, string ownerusername) // that the student takes
        {

            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "select [Course Name],courseid from Courses,[S Request T] where courses.[Course-ID]=[S Request T].courseid and [S Request T].[Student-ID]=" + sid + "and [S Request T].[Teacher-ID]=" + tid + ";";

            return dbMan.ExecuteReader(query);
        }
       // retriving the courses name and id that a student is requesting the other student used for accept,decline
        public DataTable selectcoursenamebyidfromsrs(int sid1, string ownerusername) // that the student takes
        {   
             // order matters 
            int sid2 = getidfromuserandpriv(ownerusername, 3);  // the id of one making the modification
            string query = "select [Course Name],courseid from Courses,[S Request S] where courses.[Course-ID]=[S Request S].courseid and [S Request S].sid1=" + sid1 + " and [S Request S].sid2=" + sid2+";";
             

            return dbMan.ExecuteReader(query);
        }                 
        // a query to retreive all the courses that is taught by a teacher x to a student y 
        public DataTable selectcoursenamebyidfromstos(int sid, int tid,int opened) //all courses  that the teacher has open session in
        { 
            string query = "select [Course Name],courseid from Courses,stos where courses.[Course-ID]=stos.courseid and stos.studentid=" + sid + "and opened="+opened+   "and stos.teacherid=" + tid + ";";

            return dbMan.ExecuteReader(query);
        }
        // a query to retreive all the courses that is taught by a student x to a student y 
        public DataTable selectcoursenamebyidfromssos(int sid1, string ownerusername,int opened) // that the student takes
        {   
                // it does not matter whether you are sid1 or sid2 you can end the session with the selected course 
            int sid2 = getidfromuserandpriv(ownerusername, 3);  // the id of one making the modification
            string query = "select [Course Name],courseid from Courses,ssos where courses.[Course-ID]=ssos.courseid and opened="+opened+ "and ssos.sid1=" + sid2 + " and ssos.sid2=" + sid1 +
                " union " + " select [Course Name],courseid from Courses,ssos where courses.[Course-ID]=ssos.courseid and opened=" +opened+ " and ssos.sid1="+sid1 +"and ssos.sid2="+sid2+";";

            return dbMan.ExecuteReader(query);
        }
        // retriving the student from the session with teacher whether opened or not used forviewing the info in the sesion part
        public DataTable selectmystudentsfromstos(int s, int cid,int opened)
        {

            string query = "select studentid,username from Student,STOS  where studentid=[Student-ID] and courseid=" + cid + " and teacherid=" + s + "and opened="+opened +";";
            return dbMan.ExecuteReader(query);   
           
        }
        // retriving the student from the session iwth another student whether opened or not used forviewing the info in the sesion part
        public DataTable selectmystudentsfromssos(int s, int cid,int opened)
        {

            string query = "select sid1 ,username from Student,ssos  where sid1=[Student-ID] and courseid=" + cid + "and sid2=" + s + " and opened=" + opened;
            query = query + " union " + " select sid2 ,username from Student,ssos  where sid2=[Student-ID] and courseid=" + cid + " and sid1=" + s + " and opened=" + opened;
            return dbMan.ExecuteReader(query);   
           
        }
        // retriving the teacherid from the session with another student whether opened or not used forviewing the info in the sesion part
        public DataTable selectteachersfromstos(int s, int cid,int opened)
        {

            string query = "select teacherid,username from teacher,STOS  where teacherid=[teacher-ID] and courseid=" + cid + " and studentid=" + s + "and opened="+opened +";";
            return dbMan.ExecuteReader(query);   
           
        }
        //in table sand t sessions updatding the  session opened attribute setting it to 1 when opedning a session and setting it to zero when ending the session
        public int updateopenedSTOS(int sid, int tid,int cid, int opened)
        {

            string query = " UPDATE STOS SET opened=" + opened + "Where studentid=" + sid + " and teacherid=" + tid + " and courseid=" + cid + ";";

            return dbMan.ExecuteNonQuery(query);
        }
        // updatding in table student-students the  session opened attribute setting it to 1 when opedning a session and setting it to zero when ending the session
        public int updateopenedSSOS(int sid1, int sid2,int cid, int opened)
        {


            string query = " UPDATE ssos SET opened=" + opened + "Where sid1=" + sid1 + " and sid2=" + sid2 + " and courseid=" + cid +" or sid1=" + sid2 + " and sid2=" + sid1 + " and courseid=" + cid + ";";

            return dbMan.ExecuteNonQuery(query);

        }
        // a query to get the count of all teachers or al student a speciic user is dealing with depending on the priv and the sessions whether it is opened or closed
        public int getcountofSfromSTOS(int id, int priv,int opened)  // opened relates to opened or not
        {
            string query = "";

            if(priv==2)   // i am getting the count of the students i am having a session with my id
            {

             query="select count(*) from STOS where teacherid="+id+ "and opened="+opened+";";
            
            }
            else  // my priv is 3 i am a student so i am getting the count of all teachers i study with
            {
             query = "select count(*) from STOS where studentid=" + id + "and opened=" + opened + ";";
            

            }
            return (int)dbMan.ExecuteScalar(query);
        }
        // a query that returns the count of the total number of session with the id of the student and the opened feature
        public int getcountofSfromSSOS(int id, int priv, int opened)  // opened relates to opened or not
        {

            // here priv is always sent as 3 
            if (priv == 2)
            {
                return 0;   // a test but it will never happen
            }
            
              // now returning all the number of session a student is association with // do not worry there is no here a tulpe with sid1 and sid2 and courseid having the same value 
              string  query = "select count(*) from SSOS where sid1=" + id + "and opened=" + opened + "or sid2="+id+"and opened="+opened+";";

            
            return (int)dbMan.ExecuteScalar(query);
        }
        // a query that retrive the info needed to view by other users about a student from his id 
        public DataTable selectstudentbyid(int id) // return the info of student and the name of department,faculty,college enrolled in
        {

            string query = "select [First name] ,[Last Name],Age,Gender,Phone#,city,District,Score,[Department Name],[Faculty Name],[College Name]  from Student,Department,facultynames,College where Student.[Department-ID]=Department.[Department-ID] and Student.[College-ID]=college.CollegeID and Student.[Faculty-ID]=Facultynames.[Faculty ID]" +
                " and student.[Student-ID]=" + id + ";";
             return dbMan.ExecuteReader(query);
        }
        // a query that retrive the info needed to view by other users about a teacher from his id 
        public DataTable selectteacherbyid(int id) // return the info of student and the name of department,faculty,college enrolled in
        {

            string query = "select [First name],[PriceperHour] ,[Last Name],Age,Gender,Phone#,city,District,Score,[Department Name],[Faculty Name],[College Name]  from teacher,Department,facultynames,College where teacher.[Department-ID]=Department.[Department-ID] and teacher.[College-ID]=college.CollegeID and teacher.[Faculty-ID]=Facultynames.[Faculty ID]" +
                " and teacher.[teacher-ID]=" + id + ";";
            return dbMan.ExecuteReader(query);
        }
        //  retrieves all the students  who requested a teacher to appear in the notifications section 
        public DataTable selectsr(string s)
        {
            
                string query = "select distinct [S Request T].[Student-ID],  username from   [S Request T],student where [S Request T].[Teacher-ID]=(select teacher.[Teacher-ID] from Teacher where username='" + s + "') and Student.[Student-ID]=[S Request T].[Student-ID] ;";
                return dbMan.ExecuteReader(query);
           
            
        }
         //  retrieves all the students  who requested a another student to appear in the notifications section 
        public DataTable selectsrs(string s)
        {
            // ORDER MATTERS HERE STRONGLY 
                string query = "select distinct [S Request S].sid1 ,  username from   [S Request S],student where [S Request S].sid2=(select student.[student-ID] from student where username='" + s + "') and Student.[Student-ID]=[S Request S].sid1 ;";
                return dbMan.ExecuteReader(query);
           
            
        }
        //a query to insert into the table student teacher opened session the id of the student and id of the teacher and setting opened =1
        public int insertintostos(int sid, string ownerusername,int cid)   // if u are inserting into stos you are at the first time
        {

          int tid=  getidfromuserandpriv(ownerusername,2);
          string query = "Insert into STOS(studentid,teacherid,courseid,opened) Values(" + sid + "," + tid +","+ cid +",1);";

            return dbMan.ExecuteNonQuery(query);
        }
        //a query to insert into the table student teacher opened session the id of the student and id of the other student and setting opened =1
        public int insertintossos(int sid1, int sid2,int cid)   // if u are inserting into stos you are at the first time
        {
          string query = "Insert into SSOS(sid1,sid2,courseid,opened) Values(" + sid1 + "," + sid2 +","+ cid +",1);";

            return dbMan.ExecuteNonQuery(query);
        } 
        public int deletefromstos(int id,int courseid)      // we are not using it because we are not deleting from it no more we need to keep track of every session made by our application
        {
            string query = "delete from stos where studentid=" + id + "and courseid="+ courseid +";";
            return dbMan.ExecuteNonQuery(query);
        }  
        // deleeting the request from the table srt  when the teacher either accept or decline the request sent to him
        public int deletefromsrt(int sid,int tid,int courseid)
        {
            string query = "delete from [S Request T] where [Student-ID]=" + sid + "and [Teacher-ID]=" + tid + "and courseid=" + courseid + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        // deleting the request form the table srt depedning on the requester and the requested algorithm who declined and who accepted
        public int deletefromsrs(int sid1,int sid2,int courseid)
        {     
              // you can notice here that i am deleting any pair of students with the same course 
            string query = "delete from [S Request S] where (sid1=" + sid1 + "and courseid=" + courseid + "and sid2=" + sid2 + "or sid1=" + sid2 + "and courseid=" + courseid + "and sid2=" + sid1 + ");";
            return dbMan.ExecuteNonQuery(query);
        }    
        //////////////////////// END KEFAHHHHHH ///////////////////////////
    
        public int DeleteSpots(string city, string district,int priv,int id)
        {

            string query = " ";
            if (priv == 3)
            {
                query = "delete from [s spot preferred] where [Student-ID]=" + id + " and [Spot-Id] IN (select [Spot-Id] from Spots where city='" + city + "' and district ='" + district + "');";
            }
            else if(priv==2)
            {
                query = "delete from [T spot preferred] where [Teacher-ID]=" + id + " and [Spot-Id] IN (select [Spot-Id] from Spots where city='" + city + "' and district ='" + district + "');";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        public int EnableDiscovery(int id,int priv)
        {
            string query = " ";
            if (priv == 2)
            {
                query = "UPDATE Teacher SET Discovery=1 WHERE [Teacher-Id]=" + id + ";";
            }
            else if(priv==3)
            {
                query = "UPDATE Student SET Discovery=1 WHERE [Student-Id]=" + id+ ";";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        public int DisableDiscovery(int id, int priv)
        {
            string query = " ";
            if (priv == 2)
            {
                query = "UPDATE Teacher SET Discovery=0 WHERE [Teacher-Id]= " + id + ";";
            }
            else if (priv == 3)
            {
                query = "UPDATE Student SET Discovery=0 WHERE [Student-Id] = " + id + ";";
            }
            return dbMan.ExecuteNonQuery(query);
        }


        public int insertspotpreffered(int id, int priv, string city,string disctrict)
        {

            string query2="Select [Spot-ID] from Spots where CITY='"+city+"' and district='"+ disctrict +"';";
            int spotid = (int)dbMan.ExecuteScalar(query2);
            string query = "";
            if (priv == 2)
            {
                query = "insert into [T spot Preferred] Values (" + id + "," + spotid + ");";
            }
            else if (priv == 3)
            {
                query = "insert into [S spot Preferred] Values (" + id + "," + spotid + ");";
            }

            return dbMan.ExecuteNonQuery(query);
        }

   

        /// ///////////////////////////////////////////////////////////////shorouk//////////////////////////////////////////////////////////////////////////////

        public DataTable selectcourses(string username,int priv)
        {
            string query =" ";
            int tid = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                query = "SELECT [Course Name],[Course-ID] FROM Courses c WHERE NOT EXISTS(SELECT [Course-ID] FROM [Courses T] WHERE [Teacher-ID]=" + tid + "and c.[Course-ID]= [Course-ID] ); ";
            }
            else if (priv == 3)
            {
                query = "SELECT [Course Name],[Course-ID] FROM Courses c WHERE NOT EXISTS(SELECT [Course-ID] FROM [Courses S] WHERE [Student-ID]=" + tid + " and c.[Course-ID]= [Course-ID] ); ";
            }

            return dbMan.ExecuteReader(query);
            //hena by select el courses el msh mawgoda 3ndo 3ashan y add haga gdeda matzhrolsh el hagat el 3ndo check it hatta fe query fe sql
        }

        public int InsertCourseT(string ownerusername, int cid,int priv)
        {
            int tid = getidfromuserandpriv(ownerusername, priv);
            string query = " ";
            if (priv == 2)
            {
                 query = " INSERT INTO [Courses T] VALUES (" + tid + "," + cid + ");";
            }
            else if(priv ==3 )
            { 
            query = " INSERT INTO [Courses S] VALUES (" + tid + "," + cid + ");";
        }
        
 
            return dbMan.ExecuteNonQuery(query);
            //insert selected courses by a teacher  into Course T
        }
        public int Request(int iduser, int id,int courseid,int priv)
        {
            string query = " ";
            if (priv == 3)
            {
                query = "Insert into [S Request S] Values (" + iduser + "," + id + "," + courseid + ");";

            }
            else if(priv ==2)
            {
                query = "Insert into [S Request T] Values (" + iduser + "," + id + "," + courseid + ");";
            }
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getallspotsofstudent(int id)
        {
            string query = "select City,District from Spots where [Spot-ID] IN ( select [spot-ID] from [S spot preferred] where [Student-ID]=" + id + ");";
            return dbMan.ExecuteReader(query);
            //get all id of coursees related to teacher
        }
        public DataTable getallspotsofteacher(int id)
        {
            string query = "select City,District from Spots where [Spot-ID] IN ( select [spot-ID] from [T spot preferred] where [tEACHER-ID]=" + id + ");";
            return dbMan.ExecuteReader(query);
            //get all id of coursees related to teacher
        }
       

       
        public DataTable selectcourses_withpriv(string username,int priv)
        {
      
           //hena by select el courses el msh mawgoda 3ndo 3ashan y add haga gdeda matzhrolsh el hagat el 3ndo check it hatta fe query fe sql
            int tid = getidfromuserandpriv(username, priv);
            string query = " ";
            if (priv == 2)
            {
                query = " SELECT [Course Name],[Course-ID] FROM Courses c WHERE EXISTS(SELECT [Course-ID] FROM [Courses T] WHERE [Teacher-ID]=" + tid + " and c.[Course-ID]= [Course-ID] ); ";
            }
            else if (priv == 3)
            {
                query = " SELECT [Course Name],[Course-ID] FROM Courses c WHERE EXISTS(SELECT [Course-ID] FROM [Courses S] WHERE [sTUDENT-ID]=" + tid + " and c.[Course-ID]= [Course-ID] ); ";
            }


            return dbMan.ExecuteReader(query);
        }
   
        
        public int DeleteCourseT(string ownerusername, int cid,int priv)
        {
            int tid = getidfromuserandpriv(ownerusername,priv );

            
            
            //delete selected courses by a teacher  into Course T
          
            string query = " ";
            if (priv == 2)
            {
                query = "delete from [Courses T] where [Teacher-ID]=" + tid + " and [Course-ID]=" + cid + ";";
            }
            else if (priv == 3)
            {
                query = "delete from [Courses s] where [Student-ID]=" + tid + " and [Course-ID]=" + cid + ";";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteCourseS(string ownerusername, int cid)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "delete from [Courses T] where [Teacher-ID]=" + tid + " and [Course-ID]=" + cid + ";";
            return dbMan.ExecuteNonQuery(query);
            //delete selected courses by a teacher  into Course T
        }

        public DataTable EditCollege(string ownerusername)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "SELECT [College Name],CollegeID FROM College c WHERE NOT EXISTS(SELECT [College-ID] FROM Teacher WHERE [Teacher-ID]="+tid+" and c.CollegeID= [College-ID] );";
            return dbMan.ExecuteReader(query);
        }
        public DataTable EditCollegeStudent(string ownerusername)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "SELECT [College Name],CollegeID FROM College c WHERE NOT EXISTS(SELECT [College-ID] FROM Teacher WHERE [Teacher-ID]=" + tid + " and c.CollegeID= [College-ID] );";
            return dbMan.ExecuteReader(query);
        }
        public string SelectCollege(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select [College Name] From College as d,Student as s where d.[CollegeID]=s.[College-ID] and [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select [College Name] From College as d,Teacher as s where d.[CollegeID]=s.[College-ID] and [Teacher-ID]=" + id + ";";
            }
            return(string) dbMan.ExecuteScalar(query);
        }
        public string SelectFaculty(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select [Faculty Name] From Facultynames as d,Student as s where d.[Faculty ID]=s.[Faculty-ID]and [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select [Faculty Name] From Facultynames as d,Teacher as s where d.[Faculty ID]=s.[Faculty-ID] and[Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);
        }
        public string SelectDepartment(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select [Department Name] From Department as d,Student as s where d.[Department-ID]=s.[Department-ID] and[Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select [Department Name] From Department as d,Teacher as s where d.[Department-ID]=s.[Department-ID] and[Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);
        }
        public string SelectCity(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select City From Student where [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select City From Teacher where [Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);
        }
        public string SelectDistrict(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select District From Student where [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select District From Teacher where [Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);
           
        }
        public string SelectName(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select [First Name] From Student where [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select [First Name] From Teacher where [Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);

        }
        public string SelectGender(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select Gender From Student where [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select Gender From Teacher where [Teacher-ID]=" + id + ";";
            }
            return (string)dbMan.ExecuteScalar(query);

        }
        public int SelectAge(int priv, int id)
        {
            string query = "s";
            if (priv == 3)
            {
                query = "Select Age From Student where [Student-ID]=" + id + ";";
            }
            else if (priv == 2)
            {
                query = "Select Age From Teacher where [Teacher-ID]=" + id + ";";
            }
            return (int)dbMan.ExecuteScalar(query);

        }
        public int SelectPrice(int id)
        {
            string    query = "Select [Price/Hour] From Teacher where [Teacher-ID]=" + id + ";";
            
            return (int)dbMan.ExecuteScalar(query);

        }
        public float SelectRating(int priv, int id)
        {
            float sum1;
            float sum2;
            string query = "s";
            if (priv == 3)
            {
                query = "Select Sum(rating) From [S Rates S] where [Rated]=" + id + ";";
               string query1 = "Select Sum(rating)  from [STRates] where Direction = 1 and [Student-ID]=" + id + ";";
             string   query2 = "Select count(*) From [S Rates S] where [Rated]=" + id + ";";
               string query3 = "Select count(*)  from [STRates] where Direction = 1 and [Student-ID]=" + id + ";";
               float count1 = (int)dbMan.ExecuteScalar(query2);
               float count2 = (int)dbMan.ExecuteScalar(query3);
               if (count1 + count2 == 0)
               {
                   return 0;
               }
               else 
               {
                   if(count1==0)
                   {
                       sum1=0;
                   }
                   else{
                       sum1 = (int)dbMan.ExecuteScalar(query);
                   }
                   if(count2==0)
                   {
                       sum2=0;
                   }
                   else{
                       sum2 = (int)dbMan.ExecuteScalar(query1);
                   }
               }
               return (sum1 + sum2) / (count1 + count2);

            }
            else if (priv == 2)
            {
                string query1 = "Select Sum(rating)  from [STRates] where Direction = 0 and [Student-ID]=" + id + ";";
                string query3 = "Select count(*)  from [STRates] where Direction = 0 and [Student-ID]=" + id + ";";
                float count1 = (int)dbMan.ExecuteScalar(query3);
                if (count1 == 0)
                {
                    return 0;
                }
                sum1 = (int)dbMan.ExecuteScalar(query1);
                
                return sum1 / count1;
            }

            return 0;
        }


        /////////////////////////////////////////////////////////////end ///////////////////////////////////////////////////////////////////////////////////////







        /// ///////////////////////////////////////////////////////////////shorouk//////////////////////////////////////////////////////////////////////////////

      
        public DataTable EditCollege(string ownerusername, int priv)
        {
            if (priv == 2)
            {
                int tid = getidfromuserandpriv(ownerusername, priv);
                string query = "SELECT [College Name],CollegeID FROM College c WHERE NOT EXISTS(SELECT [College-ID] FROM Teacher WHERE [Teacher-ID]=" + tid + " and c.CollegeID= [College-ID] );";
                return dbMan.ExecuteReader(query);
            }
            else if (priv == 3)
            {
                int sid = getidfromuserandpriv(ownerusername, priv);
                string query = "SELECT [College Name],CollegeID FROM College c WHERE NOT EXISTS(SELECT [College-ID] FROM Student WHERE [Student-ID]=" + sid + "and c.CollegeID= [College-ID] );";
                return dbMan.ExecuteReader(query);
            }
            return null;
        }
      
        public DataTable Selectcity() // for both
        {
            string query = "select  DISTINCT City from Spots;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectdistrict(string city1) //for both
        {
            string query = "select DISTINCT District  from Spots where City='" + city1 + "';";
            return dbMan.ExecuteReader(query);
        }

        ////////////////////////////////////////GET USER INFO///////////////////////////////////////////////////////

        public object getfname(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.[First name] from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select S.[First name] from Student S where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return dbMan.ExecuteScalar(null);
        }
        public object getlname(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.[Last Name] from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select S.[Last Name] from Student S where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return dbMan.ExecuteScalar(null);
        }
        public object getage(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select Age from Teacher where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select Age from Student where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return 0;

        }
        public object getemail(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.Email from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select S.Email from Student S where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return dbMan.ExecuteScalar(null);
        }
        public object getphone(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select Phone# from Teacher where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select Phone# from Student where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return 0;

        }
        public object getpriceperhour(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            string query = "select [Price/Hour] from Teacher where [Teacher-ID]=" + id + ";";
            return dbMan.ExecuteScalar(query);
        }
        public object getcollege(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.[College-ID] from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select [College-ID] from Student  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return 0;
        }
        public object getfaculty(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.[Faculty-ID] from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select [Faculty-ID] from Student  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return 0;
        }
        public object getdepartement(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select t.[Department-ID] from Teacher t where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select [Department-ID] from Student  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return 0;
        }
        public object getcity(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select  City from Teacher where [Teacher-ID]=;" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select  City from Student where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return dbMan.ExecuteScalar(null);
        }
        public object getdistrict(string username, int priv)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "select  District from Teacher where [Teacher-ID]=;" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            else if (priv == 3)
            {
                string query = "select  District from Student where [Student-ID]=" + id + ";";
                return dbMan.ExecuteScalar(query);
            }
            return dbMan.ExecuteScalar(null);
        }

        ///////////////updates//////////////////

        public int updateFName(string username, int priv, string name)    //update first name
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update teacher set [First name]='" + name + "' where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set [First name]='" + name + "'  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int updateLName(string username, int priv, string name)   //update last name
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update teacher set [Last name]='" + name + "' where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set [Last Name]='" + name + "'  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int updateAge(string username, int priv, int age)   //update  age
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update teacher set Age=" + age + " where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set Age=" + age + " where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int updateEmail(string username, int priv, string email)  // update email
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update teacher set Email='" + email + "' where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set Email='" + email + "'  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int updatePhoneNO(string username, int priv, int phone)    //update phone number
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update teacher set Phone#=" + phone + " where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set Phone#=" + phone + "  where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int updatePricePerHour(string username, int priv, int price) //price/hour                      teacher only
        {
            int id = getidfromuserandpriv(username, priv);
            string query = "update teacher set [Price/Hour]=" + price + "where [Teacher-ID]=" + id + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updateCollege(string username, int priv, int cid)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update Teacher  set [College-ID]=" + cid + " where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student  set [College-ID]=" + cid + " where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        } //update college
        public int updateFaculty(string username, int priv, int fid)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update Teacher  set [Faculty-ID]=" + fid + " where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student  set [Faculty-ID]=" + fid + " where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }//update faculty
        public int updateDepartment(string username, int priv, int did)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update Teacher  set [Department-ID]=" + did + " where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student  set [[Department-ID]=" + did + " where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }// update deprtment       
        public int updateCity(string username, int priv, string city1)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update Teacher set city='" + city1 + "' where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set City='" + city1 + "' where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }// update city
        public int changepassword(string username, int priv, string pass) //CHANGE PASSWORD OF USER
        {

            string query = "UPDATE users_basic SET password='" + pass + "' WHERE username= '" + username + "' and Priv=" + priv;
            return dbMan.ExecuteNonQuery(query);
        }
        public int updateDistrict(string username, int priv, string district1)
        {
            int id = getidfromuserandpriv(username, priv);
            if (priv == 2)
            {
                string query = "update Teacher set District='" + district1 + "' where [Teacher-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            else if (priv == 3)
            {
                string query = "update Student set District='" + district1 + "' where [Student-ID]=" + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        } //update disrtict


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

      

        public int InsertCourseT(string ownerusername, int cid)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = " INSERT INTO [Courses T] VALUES (" + tid + "," + cid + ");";
            return dbMan.ExecuteNonQuery(query);
            //insert selected courses by a teacher  into Course T
        }

        public DataTable getallcoursesIDofteacher(string username)
        {
            string query = "SELECT [Course Name] FROM Courses  c where  exists(SELECT * FROM [Courses T] t WHERE c.[Course-ID]=t.[Course-ID] and[Teacher-ID]=(SELECT [Teacher-ID] FROM Teacher WHERE username='" + username + "'));";
            return dbMan.ExecuteReader(query);
            //get all id of coursees related to teacher
        }

        public DataTable selectteachercourses(string ownerusername)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "select courses.[Course-ID] , [Course Name] from [Courses T],Courses where Courses.[Course-ID]= [Courses T].[Course-ID] and [Courses T].[Teacher-ID]=" + tid + "; ";
            return dbMan.ExecuteReader(query);
            // return all courses of teacher
        }

        public DataTable selectcourses_teacher(string username)
        {
            int tid = getidfromuserandpriv(username, 2);
            string query = "SELECT [Course Name],[Course-ID] FROM Courses c WHERE EXISTS(SELECT [Course-ID] FROM [Courses T] WHERE [Teacher-ID]=" + tid + "and c.[Course-ID]= [Course-ID] ); ";
            return dbMan.ExecuteReader(query);
            //hena by select el courses el msh mawgoda 3ndo 3ashan y add haga gdeda matzhrolsh el hagat el 3ndo check it hatta fe query fe sql
        }

        public int DeleteCourseT(string ownerusername, int cid)
        {
            int tid = getidfromuserandpriv(ownerusername, 2);
            string query = "delete from [Courses T] where [Teacher-ID]=" + tid + " and [Course-ID]=" + cid + ";";
            return dbMan.ExecuteNonQuery(query);
            //delete selected courses by a teacher  into Course T
        }
        public DataTable selectratings(int ownerid)
        {

            string query = "select Rated,username from [RatedStudent],Student where Rated=[Student-ID] and Rater=" + ownerid + " and status = 0 ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectratingsteacher(int ownerid)
        {

            string query = "select e.[Teacher-ID],username from [RatedTeacher] as e,Teacher as t where e.[Teacher-ID]=t.[Teacher-ID] and [Student-ID]=" + ownerid + " and status = 1 and [end]=0 ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectratingsstudent(int ownerid)
        {

            string query = "select e.[Student-ID],username from [RatedTeacher] as e,Student as t where e.[Student-ID]=t.[Student-ID] and [Teacher-ID]=" + ownerid + " and status = 0 and [end]=0 ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable checkrating(int id, int ownerid)
        {

            string query = "select Rated from [RatedStudent] where Rated =" + id + " and Rater =" + ownerid + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable checkratingts(int ownerid, int id)
        {

            string query = "select Rated from [RatedStudent] where Rated =" + id + " and Rater =" + ownerid + ";";
            return dbMan.ExecuteReader(query);
        }
        public int updateratedstudent(int ownerid, int id)
        {

            string query = " UPDATE RatedStudent SET status=1 where Rater=" + ownerid + " and Rated=" + id + " ;";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updateratedteacher(int ownerid, int id)
        {

            string query = " UPDATE RatedTeacher SET [end]=1 where [Teacher-ID]=" + ownerid + " and [Student-ID]=" + id + " ;";
            return dbMan.ExecuteNonQuery(query);
        }
        public int insertratingendss(int ownerid, int id, int status)
        {

            string query = "Insert into RatedStudent Values (" + ownerid + "," + id + "," + status + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int insertratingendts(int ownerid, int id, int status)
        {

            string query = "Insert into RatedTeacher Values (" + ownerid + "," + id + "," + status + "," + '0' + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int insertratingss(int ownerid, int id, int score)
        {

            string query = "Insert into [S Rates S] Values (" + ownerid + "," + id + "," + score + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int insertratingts(int ownerid, int id, int score, int direction)
        {

            string query = "Insert into [STRates] Values (" + direction + "," + ownerid + "," + id + "," + score + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable selectratingstudent(int ownerid, int id)
        {
            string query = "select Rat from [S Rates S] where Rat =" + ownerid + " and  Rated =" + id + " ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectratingts(int ownerid, int id, int status)
        {
            string query = "select [Teacher-ID] from [STRates] where [Teacher-ID] =" + ownerid + " and  [Student-ID] =" + id + " and Direction =" + status + " ;";
            return dbMan.ExecuteReader(query);
        }

        /////////////////////////////////////////////////////////////end ///////////////////////////////////////////////////////////////////////////////////////









    }
}
