This project aims to design and develop an integrated information system of managing operations in a dental clinic. The system is developed as part of the Programming and Development Environments course at FSEGA.
It is focused on the web application only, usng ASP.NET Core Technology.
**Key Functionalities**
- User authentication and role-based access control (admin, doctor, patient)
- Patients can create, view, update or cancel appointments
- Doctors can view their schedule and appointment details
- After each consultation, patients can leave a review for the doctor (future implementation scope)
- Admins can manage users, doctors and appointment
- Input validation on all forms (dates, non-empty fiels, email and password format)

**Database Tables Used**
- Doctor
- Patient
- Appointment
- Prescription
- Treatment

**CRUD Operations:** implemented for all used tables via user-friendly interfaces using Entity Framework Core.

**Authentication & Authorization**
- Login and registration features planned with role-specific access levels
- Only authenticated users can create or edit appointments and personal data

