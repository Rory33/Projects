import java.awt.EventQueue;

import javax.swing.JFrame;
import java.awt.Color;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import javax.swing.SwingConstants;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JTextField;
//import com.toedter.calendar.JDateChooser;

import net.proteanit.sql.DbUtils;

import javax.swing.JTable;
import javax.swing.JScrollPane;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class StudentFormManagement {

	private JFrame frmStudentFormManagement;
	private JTextField IDFld;
	private JTextField nameFld;
	private JTextField feesFld;
	private JTextField searchFld;
	
	//Connection
	Connection connection = null;
	private JTable table;
	private JTextField dobFld;
	
	//Refresh Methods
	
public void refreshTable() {
		
		try {
			
			String query = "select ID, Name, Fees, DateOfBirth from StudentInfo";
			PreparedStatement pst = connection.prepareStatement(query);
			
			ResultSet rs = pst.executeQuery();

			table.setModel(DbUtils.resultSetToTableModel(rs));
			
			rs.close();
			pst.close();

			
		} catch (Exception e2) {
			// TODO: handle exception
			System.out.println(e2.getMessage());
		}
		
	}
	
	public void refreshFld() {
		
		IDFld.setText(null);
		nameFld.setText(null);
		feesFld.setText(null);
		dobFld.setText(null);

	}

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					StudentFormManagement window = new StudentFormManagement();
					window.frmStudentFormManagement.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public StudentFormManagement() {
		initialize();
		
		connection = SqliteConnection.dbConnection();
		
		refreshFld();
		refreshTable();
		

	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frmStudentFormManagement = new JFrame();
		frmStudentFormManagement.getContentPane().setBackground(Color.YELLOW);
		frmStudentFormManagement.setTitle("Student Form Management");
		frmStudentFormManagement.setBounds(100, 100, 802, 582);
		frmStudentFormManagement.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frmStudentFormManagement.getContentPane().setLayout(null);
		
		JLabel lblNewLabel = new JLabel("LaSalle College - Student Dashboard");
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel.setFont(new Font("Tahoma", Font.BOLD, 23));
		lblNewLabel.setForeground(Color.RED);
		lblNewLabel.setBounds(143, 11, 494, 29);
		frmStudentFormManagement.getContentPane().add(lblNewLabel);
		
		JLabel lblNewLabel_1 = new JLabel("International School - Montreal Canada");
		lblNewLabel_1.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1.setFont(new Font("Tahoma", Font.BOLD, 17));
		lblNewLabel_1.setBounds(153, 51, 472, 24);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_1);
		
		JLabel lblNewLabel_2 = new JLabel("Student Information");
		lblNewLabel_2.setFont(new Font("Tahoma", Font.BOLD, 15));
		lblNewLabel_2.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_2.setBounds(277, 96, 204, 29);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_2);
		
		JLabel lblNewLabel_3 = new JLabel("");
		lblNewLabel_3.setIcon(new ImageIcon("C:\\Users\\Admin\\Desktop\\Lasalle\\Courses\\Semester_3\\OOP\\Projects\\RoryLoumami_1010886\\Asset_1\\download.png"));
		lblNewLabel_3.setBounds(10, 65, 184, 183);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_3);
		
		JButton btnInsert = new JButton("Insert");
		btnInsert.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				try {
					String query = "insert into StudentInfo (ID, Name, Fees, DateOfBirth) values (?,?,?,?)";
			
					PreparedStatement pst = connection.prepareStatement(query);
					
					pst.setString(1, IDFld.getText());
					pst.setString(2, nameFld.getText());
					pst.setString(3, feesFld.getText());
					pst.setString(4, dobFld.getText());
					
					//pst.setDate(4, dobFld.getDate());
					
					pst.execute();
					
					JOptionPane.showMessageDialog(null, "The student Data was saved!");
					pst.close();
					
					
				} catch (Exception e3) {
					// TODO: handle exception
					System.out.println(e3.getMessage());
				}
				
				refreshTable();
				refreshFld();
			}
		});
		btnInsert.setFont(new Font("Tahoma", Font.BOLD, 13));
		btnInsert.setHorizontalAlignment(SwingConstants.LEFT);
		btnInsert.setIcon(new ImageIcon("C:\\Users\\Admin\\Desktop\\Lasalle\\Courses\\Semester_3\\OOP\\Projects\\RoryLoumami_1010886\\Asset_1\\button_blue_add.png"));
		btnInsert.setBounds(599, 144, 131, 46);
		btnInsert.setFocusable(false);
		frmStudentFormManagement.getContentPane().add(btnInsert);
		
		//Update
		
		JButton btnUpdate = new JButton("Update");
		btnUpdate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				try {
					String query = "update StudentInfo set ID='" +IDFld.getText() + "', Name='" + nameFld.getText() +
							"', Fees='" + feesFld.getText() + "', DateOfBirth='" + dobFld.getText()+
							"' where ID='" + IDFld.getText() +"'";
					
					PreparedStatement pst = connection.prepareStatement(query);
					
					pst.execute();
					
					JOptionPane.showMessageDialog(null, "The Student Record was successfully updated!");
					pst.close();
					
					
				} catch (Exception e1) {
					// TODO: handle exception
					System.out.println(e1.getMessage());
				}
				
				refreshTable();
				refreshFld();
			}
		});
		btnUpdate.setIcon(new ImageIcon("C:\\Users\\Admin\\Desktop\\Lasalle\\Courses\\Semester_3\\OOP\\Projects\\RoryLoumami_1010886\\Asset_1\\button_pink_close.png"));
		btnUpdate.setHorizontalAlignment(SwingConstants.LEFT);
		btnUpdate.setFont(new Font("Tahoma", Font.BOLD, 13));
		btnUpdate.setBounds(599, 201, 131, 46);
		btnUpdate.setFocusable(false);
		frmStudentFormManagement.getContentPane().add(btnUpdate);
		
		JButton btnDelete = new JButton("Delete");
		btnDelete.addActionListener(new ActionListener() {
			
			//Delete
			
			public void actionPerformed(ActionEvent e) {
				
				int action = JOptionPane.showConfirmDialog(null, "Are you sure you want to delete this record?", "Delete", JOptionPane.YES_NO_OPTION);
				
				if(action == 0) {
					
					try {
	
						String query = "delete from StudentInfo where ID='" +IDFld.getText() +"'";
						PreparedStatement pst = connection.prepareStatement(query);
						
						pst.execute();
						
						JOptionPane.showMessageDialog(null, "The student record was deleted!");
						
						pst.close();
						
						
					} catch (Exception e3) {
						// TODO: handle exception
						System.out.println(e3.getMessage());
					}
					
					refreshTable();
					refreshFld();
				}
			}
		});
		btnDelete.setIcon(new ImageIcon("C:\\Users\\Admin\\Desktop\\Lasalle\\Courses\\Semester_3\\OOP\\Projects\\RoryLoumami_1010886\\Asset_1\\button_red_stop.png"));
		btnDelete.setHorizontalAlignment(SwingConstants.LEFT);
		btnDelete.setFont(new Font("Tahoma", Font.BOLD, 13));
		btnDelete.setBounds(599, 258, 131, 46);
		btnDelete.setFocusable(false);
		frmStudentFormManagement.getContentPane().add(btnDelete);
		
		JLabel lblNewLabel_4 = new JLabel("ID:");
		lblNewLabel_4.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_4.setBounds(225, 161, 96, 24);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_4);
		
		JLabel lblNewLabel_4_1 = new JLabel("Student Name:");
		lblNewLabel_4_1.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_4_1.setBounds(225, 192, 110, 26);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_4_1);
		
		JLabel lblNewLabel_4_1_1 = new JLabel("Fees:");
		lblNewLabel_4_1_1.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_4_1_1.setBounds(225, 229, 110, 26);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_4_1_1);
		
		JLabel lblNewLabel_4_1_2 = new JLabel("Date Of Birth:");
		lblNewLabel_4_1_2.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_4_1_2.setBounds(225, 268, 110, 26);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_4_1_2);
		
		JLabel lblNewLabel_4_1_2_1 = new JLabel("Search Student By Name:");
		lblNewLabel_4_1_2_1.setFont(new Font("Tahoma", Font.BOLD, 13));
		lblNewLabel_4_1_2_1.setBounds(143, 344, 171, 26);
		frmStudentFormManagement.getContentPane().add(lblNewLabel_4_1_2_1);
		
		IDFld = new JTextField();
		IDFld.setBounds(353, 158, 128, 20);
		frmStudentFormManagement.getContentPane().add(IDFld);
		IDFld.setColumns(10);
		
		nameFld = new JTextField();
		nameFld.setColumns(10);
		nameFld.setBounds(353, 196, 128, 20);
		frmStudentFormManagement.getContentPane().add(nameFld);
		
		feesFld = new JTextField();
		feesFld.setColumns(10);
		feesFld.setBounds(353, 233, 128, 20);
		frmStudentFormManagement.getContentPane().add(feesFld);
		
		searchFld = new JTextField();
		searchFld.addKeyListener(new KeyAdapter() {
			//Search
			@Override
			public void keyReleased(KeyEvent e) {
				
				try {
					String query = "select ID, Name, Fees, DateOfBirth from StudentInfo where Name =?";
					
					PreparedStatement pst = connection.prepareStatement(query);
	
					pst.setString(1, searchFld.getText());
					
					ResultSet rs = pst.executeQuery();
					
					table.setModel(DbUtils.resultSetToTableModel(rs));
					
					rs.close();
					pst.close();
					
				} catch (Exception e2) {
					// TODO: handle exception
					System.out.println(e2.getMessage());
				}
			}
		});
		searchFld.setColumns(10);
		searchFld.setBounds(353, 348, 128, 20);
		frmStudentFormManagement.getContentPane().add(searchFld);
		
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(89, 381, 519, 153);
		frmStudentFormManagement.getContentPane().add(scrollPane);
		
		table = new JTable();
		table.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				try {

					int row = table.getSelectedRow();
					String ID = (table.getModel().getValueAt(row, 0)).toString();
					
					String query = "select * from StudentInfo where ID= '" + ID + "'";
					
					PreparedStatement pst = connection.prepareStatement(query);
					ResultSet rs = pst.executeQuery();
					
					while(rs.next()) {
						
						IDFld.setText(rs.getString("ID"));
						nameFld.setText(rs.getString("Name"));
						feesFld.setText(rs.getString("Fees"));
						//Cant make date work with Datechooser. Switched to regular txtfld
						dobFld.setText(rs.getString("DateOfBirth"));

					}
					
					pst.close();
					rs.close();
					
				} catch (Exception e3) {
					// TODO: handle exception
					System.out.println(e3.getMessage());
				}
				
				
			}
		});
		scrollPane.setViewportView(table);
		
		dobFld = new JTextField();
		dobFld.setText((String) null);
		dobFld.setColumns(10);
		dobFld.setBounds(353, 272, 128, 20);
		frmStudentFormManagement.getContentPane().add(dobFld);
	}
}
