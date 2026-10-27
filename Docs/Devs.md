# Developer Documentation

This document is intended for developers who want to contribute to GCRM.

First of all, thank you for your interest in contributing to the codebase. People need features, and we need developers to build them.

## AI-assisted development

You are welcome to use any AI tools that help you work more effectively. However, while AI has changed the development process, it has not changed the product's standards.

You are responsible for the code you submit. AI-generated or AI-assisted code is subject to the **same level of review, scrutiny, testing, maintainability, and quality standards** as code written entirely by a developer. Using AI does not transfer responsibility for the resulting implementation.

## Stack

GCRM is a **Windows Forms client for PostgreSQL**. The application uses several third-party libraries to complement its functionality. These dependencies are listed in the main [README.md](/README.md).

## Getting Started

### 1. Install PostgreSQL

Install PostgreSQL and create a database user with superuser privileges using the following credentials:

- **Username:** `gcrm_client`
- **Password:** `m$!g+38ke~v5NrbXKH'^Zu`

> **Note:** These credentials are currently required by the development setup. Do not use them for production environments.

### 2. Set up the database

There are two ways to create the database. For the fastest setup, **the second option is recommended**.

#### Option 1: Create the schema from scratch

Run the [create_schema.sql](/GCRM/SQL/create_schema.sql) script. This creates the database tables and their initial structure.

The [create_schema.sql](/GCRM/SQL/create_schema.sql) file may occasionally be behind the latest database schema. If that happens, you will need to apply the update scripts found in the [SQL](/GCRM/SQL/) directory.

You can check the database schema version by running:

```sql
SELECT string_value
FROM settings
WHERE name LIKE 'client_version';
```

For example, the database might report version `0.1.3.2` while the current application version is `1.3.12`. In that case, run the schema update scripts in order until the database reaches the required version.

We will try to keep [create_schema.sql](/GCRM/SQL/create_schema.sql) up to date, but the individual update scripts should be considered the authoritative source for schema migrations.

#### Option 2: Restore the demo database

For a faster setup, you can restore the database from [demo.backup](/GCRM/Docs/demo.backup).

The backup may also contain an older version of the schema, so you should check the database version and apply any required update scripts afterward.

The main advantage of using the demo backup is that it includes **test data**, which can be useful when developing and testing new features.

When restoring the backup:

- Start with a clean database.
- Enable the **clear** option when restoring the backup (Otherwise, the restore may fail)

## Building and Running the Project

To build and run the project, you need **Visual Studio** with the desktop development workload and the required .NET SDKs installed.

When installing Visual Studio, select the **Desktop development** workload. This will install the tools and SDKs required to build the application.

> If you are using Visual Studio Code, make sure the appropriate .NET SDKs and build tools are installed separately. Visual Studio is currently the recommended development environment.

### First Run

On the first run, GCRM will ask for the connection information for your PostgreSQL server, including the server location and credentials.

Once configured, this information is stored in `connection.json`.

The file is created automatically during the first run and is used for subsequent connections to the database.