/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */

import Data.Student;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

/**
 *
 * @author Ana
 */
public class StudentTest {
    Student s;
    public StudentTest() {
    }
    
    @BeforeEach
    public void setUp() {
        s=new Student();
    }
    
    @AfterEach
    public void tearDown() {
    }

    /**
     * Test of Connect method, of class Student.
     */
    @Test
    public void testConnect() {
      s.Connect();
        assertTrue(s.con != null, "Connection should not be null");
    }

    /**
     * Test of Load_Class method, of class Student.
     */
    @Test
    public void testLoad_Class() {
    }

    /**
     * Test of Student_Load method, of class Student.
     */
    @Test
    public void testStudent_Load() {
    }

    /**
     * Test of main method, of class Student.
     */
    @Test
    public void testMain() {
    }
    
}
