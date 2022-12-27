create database "InternalJobDB";

\c "InternalJobDB";

CREATE TABLE "Job" (
    "JobId" CHAR(6) PRIMARY KEY,
    "JobTitle" TEXT UNIQUE NOT NULL,
     "JobDescription" TEXT,
     "Salary" numeric
);



CREATE TABLE "Skill" (

  "SkillId" CHAR(4) PRIMARY KEY,
  "SKillName" VARCHAR(20) NOT NULL,
  "SkillLevel" char(1) check ("SkillLevel" in ('B','I','A'))

);


CREATE TABLE "JobSkill" (
   "JobId" char(6) REFERENCES "Job",
   "SkillId" char(4) REFERENCES "Skill",
    "Experience" integer,
    PRIMARY KEY ("JobId","SkillId")

);


CREATE TABLE "Employee" (
   
   "EmpId" char(4) PRIMARY KEY,
   "EmpName" text not null,
   "EmailId" text,
   "PhoneNum" char(10) not null,
   "TotalExperience" integer,
    "JobId" char(6) references "Job"
);

CREATE DATABASE "EmployeeSkillsDB";

\c "EmployeeSkillsDB";

CREATE TABLE "EmpSkill"(

"EmpId" char(4) REFERENCES "Employee",
"SkillId" char(4) REFERENCES "Skill",

"SkillExperience" integer,
PRIMARY KEY("EmpId","SkillId")
);

CREATE TABLE "Employee"(
"EmpId"char(4) PRIMARY KEY
);

CREATE TABLE "Skill"(
"SkillId"char(4) PRIMARY KEY
);

CREATE DATABASE "JobPostsDB";

\c "JobPostsDB";

CREATE TABLE "JobPost"(

"PostId" char(4) PRIMARY KEY,
"JobId" char(6) references "Job", 
"DateOfPosting" date ,
"LastDate" date,
"Vacancies" integer not null
);

CREATE TABLE "Job"(

"JobId" char(6) PRIMARY KEY
);

CREATE DATABASE "EmpPostsDB";

\c "EmpPostsDB";

CREATE TABLE "EmpPost"(
"PostId" char(4) references "Post",
"EmpId" char(4) references "Employee",
"AppliedDate" date,
"ApplicationStatus" text check ("ApplicationStatus" in ("Reviewing","Accepted","Rejected")) default "Reviewing",
PRIMARY KEY ("PostId","EmpId")

);

CREATE TABLE "Post"("PostId" char(4) PRIMARY KEY);

CREATE TABLE "Employee"(
"EmpId"char(4) PRIMARY KEY
);
