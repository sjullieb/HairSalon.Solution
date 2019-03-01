CREATE DATABASE yulia_shidlovskaya;
USE yulia_shidlovskaya;
CREATE TABLE stylists(id serial PRIMARY KEY, name VARCHAR(255), email VARCHAR(255), schedule VARCHAR(255),haircut_styles VARCHAR(255));
CREATE TABLE clients(id serial PRIMARY KEY, stylist_id INT, name VARCHAR(255), email VARCHAR(255), phone VARCHAR(255));
