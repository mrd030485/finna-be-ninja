package org.tdg.twit.db;

import org.apache.commons.dbcp.ConnectionFactory;
import org.apache.commons.dbcp.DriverManagerConnectionFactory;
import org.apache.commons.dbcp.PoolableConnectionFactory;
import org.apache.commons.dbcp.PoolingDataSource;
import org.apache.commons.pool.impl.GenericObjectPool;

import javax.sql.DataSource;

public class ConnectionPool{
  public static final String DRIVER = "com.mysql.jdbc.Driver";
  public static final String URL = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAME = "fpclass";
  public static final String PASSWORD = null;

  private GenericObjectPool connectionPool = null;

  public DataSource setUp() throws Exception {
    //Load MYSQL Driver Class
    Class.forName(ConnectionPool.DRIVER).newInstance();

    connectionPool = new GenericObjectPool();
    connectionPool.setMaxActive(15);
  
    ConnectionFactory cf = new DriverManagerConnectionFactory(
      ConnectionPool.URL,
      ConnectionPool.USERNAME,
      ConnectionPool.PASSWORD);

    PoolableConnectionFactory pcf = new PoolableConnectionFactory(cf, connectionPool,null,null,false,true);
    return new PoolingDataSource(connectionPool);
  }

  public GenericObjectPool getConnectionPool(){
    return connectionPool;
  }

}
