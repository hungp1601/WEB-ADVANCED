-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- Link to schema: https://app.quickdatabasediagrams.com/#/d/3uzGG6
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

CREATE DATABASE btl_web;

use btl_web;

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [course] (
    [id] int  NOT NULL ,
    [name] nvarchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    [start_date] datetime  NOT NULL ,
    [end_date] datetime  NOT NULL ,
    [teacher_id] int  NOT NULL ,
    [visible] bit  NOT NULL ,
    CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [course_category] (
    [id] int  NOT NULL ,
    [name] nvarchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    CONSTRAINT [PK_course_category] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [course_has_categories] (
    [id] int  NOT NULL ,
    [course_id] int  NOT NULL ,
    [categorie_id] int  NOT NULL ,
    CONSTRAINT [PK_course_has_categories] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [user] (
    [id] int  NOT NULL ,
    [password] varchar  NOT NULL ,
    [full_name] nvarchar  NOT NULL ,
    [email] varchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    [status] varchar  NOT NULL ,
    [role_id] int  NOT NULL ,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [role] (
    [id] int  NOT NULL ,
    -- admin, teacher, student
    [name] nvarchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [user_has_course] (
    [id] int  NOT NULL ,
    [course_id] int  NOT NULL ,
    [user_id] int  NOT NULL ,
    [status] bit  NOT NULL ,
    CONSTRAINT [PK_user_has_course] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [lesson] (
    [id] int  NOT NULL ,
    [course_id] int  NOT NULL ,
    [name] nvarchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    [visible] bit  NOT NULL ,
    CONSTRAINT [PK_lesson] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

-- table 11
CREATE TABLE [assign] (
    [id] int  NOT NULL ,
    [name] varchar  NOT NULL ,
    [description] ntext  NOT NULL ,
    [due_date] datetime  NOT NULL ,
    [start_date] bit  NOT NULL ,
    [user_id] int  NOT NULL ,
    [lesson_id] int  NOT NULL ,
    [visible] bit  NOT NULL ,
    [url] varchar  NOT NULL ,
    CONSTRAINT [PK_assign] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

-- table 15
CREATE TABLE [attendance] (
    [id] int  NOT NULL ,
    [lesson_id] int  NOT NULL ,
    [user_id] int  NOT NULL ,
    [status] varchar  NOT NULL ,
    [attendance_time] datetime  NOT NULL ,
    [due_time] datetime  NOT NULL ,
    CONSTRAINT [PK_attendance] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

ALTER TABLE [course] WITH CHECK ADD CONSTRAINT [FK_course_teacher_id] FOREIGN KEY([teacher_id])
REFERENCES [user] ([id])

ALTER TABLE [course] CHECK CONSTRAINT [FK_course_teacher_id]

ALTER TABLE [course_has_categories] WITH CHECK ADD CONSTRAINT [FK_course_has_categories_course_id] FOREIGN KEY([course_id])
REFERENCES [course] ([id])

ALTER TABLE [course_has_categories] CHECK CONSTRAINT [FK_course_has_categories_course_id]

ALTER TABLE [course_has_categories] WITH CHECK ADD CONSTRAINT [FK_course_has_categories_categorie_id] FOREIGN KEY([categorie_id])
REFERENCES [course_category] ([id])

ALTER TABLE [course_has_categories] CHECK CONSTRAINT [FK_course_has_categories_categorie_id]

ALTER TABLE [user] WITH CHECK ADD CONSTRAINT [FK_user_role_id] FOREIGN KEY([role_id])
REFERENCES [role] ([id])

ALTER TABLE [user] CHECK CONSTRAINT [FK_user_role_id]

ALTER TABLE [user_has_course] WITH CHECK ADD CONSTRAINT [FK_user_has_course_course_id] FOREIGN KEY([course_id])
REFERENCES [course] ([id])

ALTER TABLE [user_has_course] CHECK CONSTRAINT [FK_user_has_course_course_id]

ALTER TABLE [user_has_course] WITH CHECK ADD CONSTRAINT [FK_user_has_course_user_id] FOREIGN KEY([user_id])
REFERENCES [user] ([id])

ALTER TABLE [user_has_course] CHECK CONSTRAINT [FK_user_has_course_user_id]

ALTER TABLE [lesson] WITH CHECK ADD CONSTRAINT [FK_lesson_course_id] FOREIGN KEY([course_id])
REFERENCES [course] ([id])

ALTER TABLE [lesson] CHECK CONSTRAINT [FK_lesson_course_id]

ALTER TABLE [assign] WITH CHECK ADD CONSTRAINT [FK_assign_user_id] FOREIGN KEY([user_id])
REFERENCES [user] ([id])

ALTER TABLE [assign] CHECK CONSTRAINT [FK_assign_user_id]

ALTER TABLE [assign] WITH CHECK ADD CONSTRAINT [FK_assign_lesson_id] FOREIGN KEY([lesson_id])
REFERENCES [lesson] ([id])

ALTER TABLE [assign] CHECK CONSTRAINT [FK_assign_lesson_id]

ALTER TABLE [attendance] WITH CHECK ADD CONSTRAINT [FK_attendance_lesson_id] FOREIGN KEY([lesson_id])
REFERENCES [lesson] ([id])

ALTER TABLE [attendance] CHECK CONSTRAINT [FK_attendance_lesson_id]

ALTER TABLE [attendance] WITH CHECK ADD CONSTRAINT [FK_attendance_user_id] FOREIGN KEY([user_id])
REFERENCES [user] ([id])

ALTER TABLE [attendance] CHECK CONSTRAINT [FK_attendance_user_id]

COMMIT TRANSACTION QUICKDBD