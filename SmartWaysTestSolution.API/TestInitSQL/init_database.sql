CREATE TABLE IF NOT EXISTS public.departments
(
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Phone" text COLLATE pg_catalog."default",
    CONSTRAINT departments_pkey PRIMARY KEY ("Name")
);

INSERT INTO public.departments(
    "Name", "Phone")
VALUES ('Отдел Приколов', '+7-777-777-77-77'),
       ('Отдел Анекдотов', '+7-999-999-99-99'),
       ('Отдел Мексиканцев', '+7-000-000-00-00');

CREATE TABLE IF NOT EXISTS public.passports
(
    "Number" text COLLATE pg_catalog."default" NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    CONSTRAINT passports_pkey PRIMARY KEY ("Number")
);

INSERT INTO public.passports(
    "Number", "Type")
VALUES ('4445-2535', 'Default'),
       ('4456-2532', 'Default'),
       ('5567-4551', 'Default'),
       ('5864-5165', 'Default'),
       ('7775-1567', 'Default');

CREATE TABLE IF NOT EXISTS public.employees
(
    "Id" integer NOT NULL,
    "Name" text COLLATE pg_catalog."default",
    "Surname" text COLLATE pg_catalog."default",
    "Phone" text COLLATE pg_catalog."default",
    "CompanyId" integer,
    "PassportNumber" text COLLATE pg_catalog."default" NOT NULL,
    "DepartmentName" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT employees_pkey PRIMARY KEY ("Id"),
    CONSTRAINT employees_department_name_fkey FOREIGN KEY ("DepartmentName")
        REFERENCES public.departments ("Name") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT employees_passport_number_fkey FOREIGN KEY ("PassportNumber")
        REFERENCES public.passports ("Number") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

INSERT INTO public.employees(
    "Id", "Name", "Surname", "Phone", "CompanyId", "PassportNumber", "DepartmentName")
VALUES (1, 'Максим', 'Максимов', '+1-111-111-11-11', 0, '4445-2535', 'Отдел Приколов'),
       (2, 'Александр', 'Александров', '+2-222-222-22-22', 0, '4456-2532', 'Отдел Приколов'),
       (3, 'Пётр', 'Петров', '+3-333-333-33-33', 1, '5567-4551', 'Отдел Анекдотов'),
       (4, 'Аксён', 'Аксёнов', '+4-444-444-44-44', 1, '5864-5165', 'Отдел Анекдотов'),
       (5, 'А', 'Б', '+5-555-555-55-55', 2, '7775-1567', 'Отдел Мексиканцев');