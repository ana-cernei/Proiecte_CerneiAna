package Data;


import Main.Menu;
import Authentification.login;
import com.mysql.cj.jdbc.result.ResultSetMetaData;
import java.lang.System.Logger;
import java.lang.System.Logger.Level;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Vector;
import javax.swing.JOptionPane;
import javax.swing.table.DefaultTableModel;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/GUIForms/JFrame.java to edit this template
 */

/**
 * This class represents an application for managing student information.
 * It allows users to add, edit, delete, and search for students,also this class uses a table to display and manipulate the data.
 * The data is stored in a MySQL database.
 * This class uses a table to display and manipulate the data.
 * 
 * @author Ana
 */
public class Student extends javax.swing.JFrame {

    /**
     *Creates new form Student
     *Initializes the components, connects to the database, and loads initial data.
     */
    public Student() {
        initComponents();
        Connect();
        Load_Class();
        Student_Load();
    }
    Connection con;
    PreparedStatement pst;
    java.sql.ResultSet rs;
    DefaultTableModel d;
     /**
     * Establishes a connection to the MySQL database.
     */
     public void Connect ()
    {
        try
        {
          Class.forName("com.mysql.cj.jdbc.Driver");
                con = DriverManager.getConnection("jdbc:mysql://localhost:3306/student", "root", "");

        }catch (Exception ex){
            System.out.println(ex.getMessage()); 
        }
        
    }
       /**
     * Loads available majors and populates the corresponding combo box.
     */
     public void Load_Class()
     {
      try{
          pst=con.prepareStatement("select Distinct major from class");
          rs=pst.executeQuery();
          txtmajor.removeAllItems();
          while(rs.next())
          {
              txtmajor.addItem(rs.getString("major"));
              
          }

}catch (SQLException ex){
    JOptionPane.showMessageDialog(this, "Error: " + ex.getMessage());
        }
     }
     
     /**
     * Loads student data from the database and data is shown in the table.
     * */
     
public void Student_Load()
{
    int c;
    try{
        pst=con.prepareStatement("select * from students");
        rs = pst.executeQuery();
        
        ResultSetMetaData rsd=(ResultSetMetaData) rs.getMetaData();
        c=rsd.getColumnCount();
        
        d=(DefaultTableModel)jTable1.getModel();
        d.setRowCount(0);
        
        while(rs.next())
        {
            Vector v2=new Vector();
            for(int i=1;i<=c;i++)
            {
                 v2.add(rs.getString("id"));
                 v2.add(rs.getString("name"));
                 v2.add(rs.getString("Age"));
                 v2.add(rs.getString("Gender"));
                 v2.add(rs.getString("Address"));
                 v2.add(rs.getString("College"));
                 v2.add(rs.getString("Phone"));
                 v2.add(rs.getString("Major")); 
                 v2.add(rs.getString("Section"));
            }
            d.addRow(v2);
        }   
    }catch(SQLException ex){
               java.util.logging.Logger.getLogger(login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
    }
}
     
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        txtstname = new javax.swing.JTextField();
        txtage = new javax.swing.JTextField();
        txtgender = new javax.swing.JComboBox<>();
        txtaddress = new javax.swing.JTextField();
        txtcollege = new javax.swing.JTextField();
        txtphone = new javax.swing.JTextField();
        txtmajor = new javax.swing.JComboBox<>();
        txtsection = new javax.swing.JComboBox<>();
        jLabel9 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTable1 = new javax.swing.JTable();
        Save = new javax.swing.JButton();
        Edit = new javax.swing.JButton();
        Delete = new javax.swing.JButton();
        Clear = new javax.swing.JButton();
        Menu = new javax.swing.JButton();
        search = new javax.swing.JTextField();
        searchbutton = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jPanel1.setBackground(new java.awt.Color(0, 0, 0));
        jPanel1.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.RAISED));
        jPanel1.setForeground(new java.awt.Color(255, 255, 255));

        jLabel1.setBackground(new java.awt.Color(0, 0, 0));
        jLabel1.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel1.setForeground(new java.awt.Color(255, 255, 255));
        jLabel1.setText("Student Name");

        jLabel2.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel2.setForeground(new java.awt.Color(255, 255, 255));
        jLabel2.setText("Age");

        jLabel3.setBackground(new java.awt.Color(0, 0, 0));
        jLabel3.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel3.setForeground(new java.awt.Color(255, 255, 255));
        jLabel3.setText("Gender");

        jLabel4.setBackground(new java.awt.Color(0, 0, 0));
        jLabel4.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel4.setForeground(new java.awt.Color(255, 255, 255));
        jLabel4.setText("Address");

        jLabel5.setBackground(new java.awt.Color(0, 0, 0));
        jLabel5.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel5.setForeground(new java.awt.Color(255, 255, 255));
        jLabel5.setText("College");

        jLabel6.setBackground(new java.awt.Color(0, 0, 0));
        jLabel6.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel6.setForeground(new java.awt.Color(255, 255, 255));
        jLabel6.setText("Phone");

        jLabel7.setBackground(new java.awt.Color(0, 0, 0));
        jLabel7.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel7.setForeground(new java.awt.Color(255, 255, 255));
        jLabel7.setText("Section");

        jLabel8.setBackground(new java.awt.Color(0, 0, 0));
        jLabel8.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel8.setForeground(new java.awt.Color(255, 255, 255));
        jLabel8.setText("Major");

        txtage.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtageActionPerformed(evt);
            }
        });

        txtgender.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Male", "Female" }));

        txtsection.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", " " }));

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(82, 82, 82)
                                .addComponent(jLabel3)
                                .addGap(46, 46, 46))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                                .addGap(79, 79, 79)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel5, javax.swing.GroupLayout.PREFERRED_SIZE, 76, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                        .addComponent(jLabel1)
                                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel4, javax.swing.GroupLayout.PREFERRED_SIZE, 76, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGroup(jPanel1Layout.createSequentialGroup()
                                                .addGap(4, 4, 4)
                                                .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addComponent(jLabel8))
                                        .addGroup(jPanel1Layout.createSequentialGroup()
                                            .addComponent(jLabel6)
                                            .addGap(45, 45, 45))))
                                .addGap(9, 9, 9)))
                        .addGap(8, 8, 8))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel7, javax.swing.GroupLayout.PREFERRED_SIZE, 52, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(41, 41, 41)))
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(txtsection, javax.swing.GroupLayout.Alignment.TRAILING, 0, 90, Short.MAX_VALUE)
                    .addComponent(txtmajor, javax.swing.GroupLayout.Alignment.TRAILING, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(txtphone, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(txtcollege, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(txtaddress, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(txtgender, javax.swing.GroupLayout.Alignment.TRAILING, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(txtstname, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(txtage))
                .addContainerGap())
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGap(26, 26, 26)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(txtstname, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel2)
                    .addComponent(txtage, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(txtgender, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel4)
                    .addComponent(txtaddress, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel5)
                    .addComponent(txtcollege, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel6)
                    .addComponent(txtphone, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(21, 21, 21)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel8)
                    .addComponent(txtmajor, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(23, 23, 23)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel7)
                    .addComponent(txtsection, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(22, Short.MAX_VALUE))
        );

        jLabel9.setFont(new java.awt.Font("Times New Roman", 1, 20)); // NOI18N
        jLabel9.setText("Students");

        jTable1.setBackground(new java.awt.Color(0, 0, 0));
        jTable1.setForeground(new java.awt.Color(255, 255, 255));
        jTable1.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "Id", "Student Name", "Age", "Gender", "Address", "College", "Phone", "Major", "Section"
            }
        ) {
            Class[] types = new Class [] {
                java.lang.Integer.class, java.lang.String.class, java.lang.Integer.class, java.lang.String.class, java.lang.String.class, java.lang.String.class, java.lang.Integer.class, java.lang.String.class, java.lang.Integer.class
            };

            public Class getColumnClass(int columnIndex) {
                return types [columnIndex];
            }
        });
        jTable1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jTable1MouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(jTable1);

        Save.setText("SAVE");
        Save.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                SaveActionPerformed(evt);
            }
        });

        Edit.setText("EDIT");
        Edit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                EditActionPerformed(evt);
            }
        });

        Delete.setText("DELETE");
        Delete.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                DeleteActionPerformed(evt);
            }
        });

        Clear.setText("CLEAR");
        Clear.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ClearActionPerformed(evt);
            }
        });

        Menu.setText("Go back to menu");
        Menu.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                MenuActionPerformed(evt);
            }
        });

        searchbutton.setText("SEARCH");
        searchbutton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                searchbuttonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(83, 83, 83)
                .addComponent(jLabel9, javax.swing.GroupLayout.PREFERRED_SIZE, 83, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(141, 141, 141)
                .addComponent(search, javax.swing.GroupLayout.PREFERRED_SIZE, 253, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(45, 45, 45)
                .addComponent(searchbutton)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(6, 6, 6)
                        .addComponent(Save)
                        .addGap(33, 33, 33)
                        .addComponent(Edit)
                        .addGap(27, 27, 27)
                        .addComponent(Delete)
                        .addGap(18, 18, 18)
                        .addComponent(Clear)
                        .addGap(28, 28, 28)
                        .addComponent(Menu))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(24, 24, 24)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 607, Short.MAX_VALUE)
                        .addContainerGap())))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(21, 21, 21)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel9)
                    .addComponent(search, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(searchbutton))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 364, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 10, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(Save)
                    .addComponent(Edit)
                    .addComponent(Delete)
                    .addComponent(Clear)
                    .addComponent(Menu))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void txtageActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtageActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtageActionPerformed
/**
     * Saves a new student record to the 'students' table.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void SaveActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_SaveActionPerformed
         String name=txtstname.getText();
         String age=txtage.getText();
         String  gender =txtgender.getSelectedItem().toString();
         String address=txtaddress.getText();
         String college=txtcollege.getText();
         String phone=txtphone.getText();
         String  major =txtmajor.getSelectedItem().toString();
         String  section =txtsection.getSelectedItem().toString();

           try {
               pst=con.prepareStatement("insert into students(name,Age,Gender,Address,College,Phone,Major,Section) values(?,?,?,?,?,?,?,?)");
          
            pst.setString(1,name);
            pst.setString(2,age);
            pst.setString(3,gender);
            pst.setString(4,address);
            pst.setString(5,college);
            pst.setString(6,phone); 
            pst.setString(7,major);
            pst.setString(8,section);  
                
            pst.executeUpdate();
            JOptionPane.showMessageDialog(this, "Student inserted successfully!");
            Student_Load();
           
             } catch (SQLException ex) {
               java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
           }
    }//GEN-LAST:event_SaveActionPerformed
 /**
     * Handles the click event on a table row, allowing the user to edit the selected student record.
     *
     * @param evt MouseEvent representing the mouse click event.
     */
    private void jTable1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jTable1MouseClicked
         d=(DefaultTableModel)jTable1.getModel();
      int selectIndex=jTable1.getSelectedRow();
      
      String id =d.getValueAt(selectIndex, 0).toString();
      txtstname.setText(d.getValueAt(selectIndex, 1).toString());
      txtage.setText(d.getValueAt(selectIndex, 2).toString());
      txtgender.setSelectedItem(d.getValueAt(selectIndex, 3).toString());
      txtaddress.setText(d.getValueAt(selectIndex, 4).toString());
      txtcollege.setText(d.getValueAt(selectIndex, 5).toString());
      txtphone.setText(d.getValueAt(selectIndex, 6).toString());
      txtmajor.setSelectedItem(d.getValueAt(selectIndex, 7).toString());
      txtsection.setSelectedItem(d.getValueAt(selectIndex, 8).toString());
      
    }//GEN-LAST:event_jTable1MouseClicked
/**
     * Edits the selected student record in the 'students' table and database.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void EditActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_EditActionPerformed
         d=(DefaultTableModel)jTable1.getModel();
      int selectIndex=jTable1.getSelectedRow();
      String id =d.getValueAt(selectIndex, 0).toString();
      
      
         String name=txtstname.getText();
         String age=txtage.getText();
         String gender =txtgender.getSelectedItem().toString();
         String address=txtaddress.getText();
         String college=txtcollege.getText();
         String phone=txtphone.getText();
         String major =txtmajor.getSelectedItem().toString();
         String section =txtsection.getSelectedItem().toString();

           try {
               pst=con.prepareStatement("update students set name= ?,Age=?,Gender=?,Address=?,College=?,Phone=?,Major=?,Section=? where id=?");
           
            pst.setString(1,name);
            pst.setString(2,age);
            pst.setString(3,gender);
            pst.setString(4,address);
            pst.setString(5,college);
            pst.setString(6,phone); 
            pst.setString(7,major);
            pst.setString(8,section);  
            pst.setString(9,id);
                
            pst.executeUpdate();
            JOptionPane.showMessageDialog(this, "Student edited successfully!");
            Student_Load();
           
             } catch (SQLException ex) {
               java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
           }
    }//GEN-LAST:event_EditActionPerformed
 /**
     * Deletes the selected student record from the 'students' table and database.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void DeleteActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_DeleteActionPerformed
                                     
    try {
        d = (DefaultTableModel) jTable1.getModel();
        int selectIndex = jTable1.getSelectedRow();
        String id = d.getValueAt(selectIndex, 0).toString();
        
        // Archive the deleted student
        pst = con.prepareStatement("INSERT INTO student_archive (Name, Age, Gender, Address, College, Phone, Major, Section) " +
                                   "SELECT name, Age, Gender, Address, College, Phone, Major, Section " +
                                   "FROM students WHERE id = ?");
        pst.setString(1, id);
        pst.executeUpdate();
        
        // Delete from the main table
        pst = con.prepareStatement("DELETE FROM students WHERE id = ?");
        pst.setString(1, id);
        pst.executeUpdate();

        JOptionPane.showMessageDialog(this, "Student deleted and archived successfully!");

        Student_Load();

    } catch (SQLException ex) {
        JOptionPane.showMessageDialog(this, "Error: " + ex.getMessage());
    }


    }//GEN-LAST:event_DeleteActionPerformed
/**
     * Clears the input fields and reloads the student records.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void ClearActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ClearActionPerformed
      txtstname.setText("");
      txtage.setText("");
      txtgender.setSelectedIndex(-1);
      txtaddress.setText("");
      txtcollege.setText("");
      txtphone.setText("");
      txtmajor.setSelectedIndex(-1);
      txtsection.setSelectedIndex(-1);
      Student_Load();
    }//GEN-LAST:event_ClearActionPerformed
 /**
     * Navigates back to the main menu.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void MenuActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MenuActionPerformed
    Menu menu = new Menu();
    menu.setVisible(true);
    this.dispose();
    }//GEN-LAST:event_MenuActionPerformed

    /**
     * Searches for student records based on the entered name and updates the table with the searched values.
     *
     * @param evt ActionEvent representing the button click event.
     */
    private void searchbuttonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_searchbuttonActionPerformed
      String searchName = search.getText();

    try {
        pst = con.prepareStatement("SELECT * FROM students WHERE name LIKE ?");
        pst.setString(1, "%" + searchName + "%");
        rs = pst.executeQuery();

        // Clear existing table data
        d.setRowCount(0);

        while (rs.next()) {
            Vector v2 = new Vector();
            for (int i = 1; i <= 9; i++) {
                v2.add(rs.getString("id"));
                v2.add(rs.getString("name"));
                v2.add(rs.getString("Age"));
                v2.add(rs.getString("Gender"));
                v2.add(rs.getString("Address"));
                v2.add(rs.getString("College"));
                v2.add(rs.getString("Phone"));
                v2.add(rs.getString("Major"));
                v2.add(rs.getString("Section"));
            }
            d.addRow(v2);
        }

    } catch (SQLException ex) {
        java.util.logging.Logger.getLogger(login.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        JOptionPane.showMessageDialog(this, "Error: " + ex.getMessage());
    }
    }//GEN-LAST:event_searchbuttonActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Student.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Student().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton Clear;
    private javax.swing.JButton Delete;
    private javax.swing.JButton Edit;
    private javax.swing.JButton Menu;
    private javax.swing.JButton Save;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable jTable1;
    private javax.swing.JTextField search;
    private javax.swing.JButton searchbutton;
    private javax.swing.JTextField txtaddress;
    private javax.swing.JTextField txtage;
    private javax.swing.JTextField txtcollege;
    private javax.swing.JComboBox<String> txtgender;
    private javax.swing.JComboBox<String> txtmajor;
    private javax.swing.JTextField txtphone;
    private javax.swing.JComboBox<String> txtsection;
    private javax.swing.JTextField txtstname;
    // End of variables declaration//GEN-END:variables
}