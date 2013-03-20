package org.tdg.twit.gui;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JLabel;
import java.awt.Font;
import javax.swing.SwingConstants;
import javax.swing.JTabbedPane;
import javax.swing.JTextArea;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.JTextField;
import java.awt.Color;
import javax.swing.JSeparator;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JMenu;
import javax.swing.JPasswordField;
import javax.swing.JButton;
import javax.swing.ButtonGroup;
import javax.swing.AbstractAction;
import java.awt.event.ActionEvent;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

import javax.swing.Action;
import javax.swing.KeyStroke;
import java.awt.event.KeyEvent;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class controlPanel {

	private JFrame frame;
	private JTextField statementsTextField;
	private JTextField keywordsTextField;
	private JTextField textField;
	private JPasswordField passwordField;
	/**
	 * Launch the application.
	 */
	public static void ccPanel(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					controlPanel window = new controlPanel();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public controlPanel() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 500, 584);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		JPanel panel = new JPanel();
		panel.setBounds(5, 5, 490, 525);
		frame.getContentPane().add(panel);
		panel.setLayout(null);
		
		JLabel lblFpClassifier = new JLabel("FP - Classifier");
		lblFpClassifier.setVerticalAlignment(SwingConstants.BOTTOM);
		lblFpClassifier.setHorizontalAlignment(SwingConstants.CENTER);
		lblFpClassifier.setFont(new Font("Century Schoolbook L", Font.BOLD, 24));
		lblFpClassifier.setBounds(12, 12, 466, 39);
		panel.add(lblFpClassifier);
		
		JTabbedPane tabbedControlCenter = new JTabbedPane(JTabbedPane.TOP);
		tabbedControlCenter.setBounds(12, 63, 466, 340);
		panel.add(tabbedControlCenter);
		
		JPanel startPanel = new JPanel();
		tabbedControlCenter.addTab("Control Center", null, startPanel, null);
		
		JLabel lblSystemStatistics = new JLabel("System Statistics");
		
		JSeparator separator = new JSeparator();
		
		JLabel lblWebsiteStatistics = new JLabel("Website Statistics");
		
		JSeparator separator_1 = new JSeparator();
		GroupLayout gl_startPanel = new GroupLayout(startPanel);
		gl_startPanel.setHorizontalGroup(
			gl_startPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_startPanel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_startPanel.createParallelGroup(Alignment.LEADING)
						.addComponent(lblSystemStatistics)
						.addComponent(separator, GroupLayout.PREFERRED_SIZE, 451, GroupLayout.PREFERRED_SIZE))
					.addContainerGap(GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
				.addGroup(Alignment.TRAILING, gl_startPanel.createSequentialGroup()
					.addContainerGap(GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
					.addGroup(gl_startPanel.createParallelGroup(Alignment.LEADING)
						.addComponent(separator_1, GroupLayout.PREFERRED_SIZE, 451, GroupLayout.PREFERRED_SIZE)
						.addComponent(lblWebsiteStatistics))
					.addContainerGap())
		);
		gl_startPanel.setVerticalGroup(
			gl_startPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_startPanel.createSequentialGroup()
					.addContainerGap()
					.addComponent(lblSystemStatistics)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(separator, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addGap(110)
					.addComponent(lblWebsiteStatistics)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(separator_1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addContainerGap(145, Short.MAX_VALUE))
		);
		startPanel.setLayout(gl_startPanel);
		
		JPanel settingPanel = new JPanel();
		tabbedControlCenter.addTab("Settings", null, settingPanel, null);
		
		JLabel lblNewPosts = new JLabel("New Posts?");
		
		JLabel lblCollectData = new JLabel("Collect Data?");
		
		JLabel lblUserId = new JLabel("User ID:");
		
		JLabel lblPassword = new JLabel("Password:");
		
		textField = new JTextField();
		textField.setColumns(10);
		
		passwordField = new JPasswordField();
		
		JButton btnSave = new JButton("Save");
		GroupLayout gl_settingPanel = new GroupLayout(settingPanel);
		gl_settingPanel.setHorizontalGroup(
			gl_settingPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_settingPanel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_settingPanel.createParallelGroup(Alignment.LEADING)
						.addComponent(lblNewPosts)
						.addComponent(lblCollectData)
						.addGroup(gl_settingPanel.createParallelGroup(Alignment.LEADING)
							.addGroup(gl_settingPanel.createSequentialGroup()
								.addComponent(lblUserId)
								.addGap(52)
								.addGroup(gl_settingPanel.createParallelGroup(Alignment.LEADING, false)
									.addComponent(passwordField)
									.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
									.addComponent(btnSave, Alignment.TRAILING)))
							.addComponent(lblPassword)))
					.addContainerGap(224, Short.MAX_VALUE))
		);
		gl_settingPanel.setVerticalGroup(
			gl_settingPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_settingPanel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_settingPanel.createParallelGroup(Alignment.TRAILING)
						.addGroup(gl_settingPanel.createSequentialGroup()
							.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(passwordField, GroupLayout.PREFERRED_SIZE, 19, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_settingPanel.createSequentialGroup()
							.addComponent(lblNewPosts)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(lblCollectData)
							.addGap(48)
							.addComponent(lblUserId)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(lblPassword)))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(btnSave)
					.addContainerGap(159, Short.MAX_VALUE))
		);
		settingPanel.setLayout(gl_settingPanel);
		
		JPanel statusPanel = new JPanel();
		tabbedControlCenter.addTab("Status", null, statusPanel, null);
		
		JLabel lblStatementsCollected = new JLabel("Statements:");
		
		JLabel lblKeywords = new JLabel("Keywords:");
		
		statementsTextField = new JTextField();
		statementsTextField.setColumns(10);
		
		keywordsTextField = new JTextField();
		keywordsTextField.setColumns(10);
		
		JLabel lblSystem = new JLabel("System:");
		
		JLabel lblNewLabel = new JLabel("OK");
		lblNewLabel.setForeground(Color.GREEN);
		GroupLayout gl_statusPanel = new GroupLayout(statusPanel);
		gl_statusPanel.setHorizontalGroup(
			gl_statusPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_statusPanel.createSequentialGroup()
					.addGap(105)
					.addGroup(gl_statusPanel.createParallelGroup(Alignment.LEADING)
						.addComponent(lblStatementsCollected)
						.addComponent(lblKeywords)
						.addComponent(lblSystem))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addGroup(gl_statusPanel.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_statusPanel.createSequentialGroup()
							.addComponent(lblNewLabel)
							.addGap(236))
						.addGroup(gl_statusPanel.createSequentialGroup()
							.addGroup(gl_statusPanel.createParallelGroup(Alignment.LEADING)
								.addComponent(keywordsTextField, GroupLayout.DEFAULT_SIZE, 150, Short.MAX_VALUE)
								.addComponent(statementsTextField, GroupLayout.PREFERRED_SIZE, 150, GroupLayout.PREFERRED_SIZE))
							.addGap(156))))
		);
		gl_statusPanel.setVerticalGroup(
			gl_statusPanel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_statusPanel.createSequentialGroup()
					.addContainerGap()
					.addGroup(gl_statusPanel.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_statusPanel.createSequentialGroup()
							.addComponent(lblStatementsCollected)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(lblKeywords))
						.addGroup(gl_statusPanel.createSequentialGroup()
							.addComponent(statementsTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(keywordsTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)))
					.addGap(47)
					.addGroup(gl_statusPanel.createParallelGroup(Alignment.BASELINE)
						.addComponent(lblSystem)
						.addComponent(lblNewLabel))
					.addContainerGap(195, Short.MAX_VALUE))
		);
		statusPanel.setLayout(gl_statusPanel);
		
		JTextArea consoleDisplay = new JTextArea();
		consoleDisplay.setBounds(12, 415, 466, 101);
		panel.add(consoleDisplay);
		
		JMenuBar menuBar = new JMenuBar();
		frame.setJMenuBar(menuBar);
		
		JMenu mnFile = new JMenu("File");
		menuBar.add(mnFile);
		
		JMenuItem mntmLog = new JMenuItem("Log");
		mntmLog.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_L, InputEvent.CTRL_MASK));
		mnFile.add(mntmLog);
		
		JMenuItem mntmExit = new JMenuItem("Exit");
		mntmExit.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_X, InputEvent.CTRL_MASK));
		mnFile.add(mntmExit);
		
		mntmExit.addActionListener(new ExitListener()); 
        WindowListener exitListener = new WindowAdapter() {

            @Override
            public void windowClosing(WindowEvent e) {
                int confirm = JOptionPane.showOptionDialog(frame,
                        "Are You Sure to Close this Application?",
                        "Exit Confirmation", JOptionPane.YES_NO_OPTION,
                        JOptionPane.QUESTION_MESSAGE, null, null, null);
                if (confirm == JOptionPane.YES_OPTION) {
                    System.exit(0);
                }
            }
        };
        frame.addWindowListener(exitListener);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JMenu mnAbout = new JMenu("About");
		menuBar.add(mnAbout);
		
		JMenuItem mntmHelp = new JMenuItem("Help");
		mntmHelp.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_F1, 0));
		mnAbout.add(mntmHelp);
		
		JMenuItem mntmAbout = new JMenuItem("About");
		mnAbout.add(mntmAbout);
	}
	
	private class ExitListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            int confirm = JOptionPane.showOptionDialog(frame,
                    "Are You Sure to Close this Application?",
                    "Exit Confirmation", JOptionPane.YES_NO_OPTION,
                    JOptionPane.QUESTION_MESSAGE, null, null, null);
            if (confirm == JOptionPane.YES_OPTION) {
                System.exit(0);
            }
        }
    }
}
