using System;
using System.Collections.Generic;
using System.Linq;

// Model classes
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
}

public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
}

// Service classes for CRUD operations
public class CourseService
{
    private List<Course> _courses;

    public CourseService()
    {
        _courses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        _courses.Add(course);
    }

    public Course GetCourseById(int id)
    {
        return _courses.FirstOrDefault(c => c.Id == id);
    }

    public void UpdateCourse(Course updatedCourse)
    {
        var existingCourse = _courses.FirstOrDefault(c => c.Id == updatedCourse.Id);
        if (existingCourse != null)
        {
            existingCourse.Name = updatedCourse.Name;
            existingCourse.CategoryId = updatedCourse.CategoryId;
            existingCourse.InstructorId = updatedCourse.InstructorId;
        }
    }

    public void DeleteCourse(int id)
    {
        var courseToRemove = _courses.FirstOrDefault(c => c.Id == id);
        if (courseToRemove != null)
        {
            _courses.Remove(courseToRemove);
        }
    }
}

public class CategoryService
{
    private List<Category> _categories;

    public CategoryService()
    {
        _categories = new List<Category>();
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }

    public Category GetCategoryById(int id)
    {
        return _categories.FirstOrDefault(c => c.Id == id);
    }

    public void UpdateCategory(Category updatedCategory)
    {
        var existingCategory = _categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = updatedCategory.Name;
        }
    }

    public void DeleteCategory(int id)
    {
        var categoryToRemove = _categories.FirstOrDefault(c => c.Id == id);
        if (categoryToRemove != null)
        {
            _categories.Remove(categoryToRemove);
        }
    }
}

public class InstructorService
{
    private List<Instructor> _instructors;

    public InstructorService()
    {
        _instructors = new List<Instructor>();
    }

    public void AddInstructor(Instructor instructor)
    {
        _instructors.Add(instructor);
    }

    public Instructor GetInstructorById(int id)
    {
        return _instructors.FirstOrDefault(i => i.Id == id);
    }

    public void UpdateInstructor(Instructor updatedInstructor)
    {
        var existingInstructor = _instructors.FirstOrDefault(i => i.Id == updatedInstructor.Id);
        if (existingInstructor != null)
        {
            existingInstructor.Name = updatedInstructor.Name;
        }
    }

    public void DeleteInstructor(int id)
    {
        var instructorToRemove = _instructors.FirstOrDefault(i => i.Id == id);
        if (instructorToRemove != null)
        {
            _instructors.Remove(instructorToRemove);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sample usage
        var categoryService = new CategoryService();
        var courseService = new CourseService();
        var instructorService = new InstructorService();

        // Adding sample data
        var category = new Category { Id = 1, Name = "Programming" };
        categoryService.AddCategory(category);

        var instructor = new Instructor { Id = 1, Name = "ftetik" };
        instructorService.AddInstructor(instructor);

        var course = new Course { Id = 1, Name = "C# Programming", CategoryId = 1, InstructorId = 1 };
        courseService.AddCourse(course);

        // Retrieving and displaying course details
        var retrievedCourse = courseService.GetCourseById(1);
        if (retrievedCourse != null)
        {
            Console.WriteLine($"Course Name: {retrievedCourse.Name}");
            Console.WriteLine($"Category: {categoryService.GetCategoryById(retrievedCourse.CategoryId)?.Name}");
            Console.WriteLine($"Instructor: {instructorService.GetInstructorById(retrievedCourse.InstructorId)?.Name}");
        }
    }
}
