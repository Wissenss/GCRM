# Installation

## 1 database setup

- 1.1 install postgress
- 1.2 create a new database
- 1.3 add a new user, this will be used by the application it must have the credentials: 

USERNAME: gcrm_client
PASSWORD: m$!g+38ke~v5NrbXKH'^Zu

- 1.4 run the initialization script create_schema.sql

- 1.5 (optional) to allow connecting from different devices a couple things have to be setup in the postgress server and host computer

- 1.5.1 configure the postgresql.conf
- 1.5.1.1 navigate to C:\Program Files\PostgreSQL\<version>\data\ 
- 1.5.1.2 open the file postgresql.conf
- 1.5.1.3 find the line #listen_addresses = 'localhost' and change it to listen_addresses = '*'
- 1.5.1.4 save and close the file

- 1.5.2 configure the pg_hba.conf
- 1.5.2.1 in the same data directory open the pg_hba.conf file
- 1.5.2.2 add the following line to the ond of the file to allow connections from every ip
"host    all             all             0.0.0.0/0            md5"

- 1.5.3 open the port in windows firewall
- 1.5.4 restart the posgresql service

## 2 client setup

- 2.1 download the binary files, prefered/default installation path is C:\Program Files\GCRM\
- 2.2 (optional) create a .lnk direct access file of GCRM.exe and place it on desktop and or starup folder
- 2.3 (optional) disable security warning for the application
- 2.3.1 first time the app ir runned, a security warning will show advaicing not to run, click more and run anyway
- 2.4 login with superuser to create all users, the credentials are:

USERNAM: root
PASSWORD: trafficJam32