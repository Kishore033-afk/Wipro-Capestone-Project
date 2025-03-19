import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchCourses } from "../store/slices/courseSlice";
import { CourseCard } from "../components/CourseCard";

export const Home = () => {
  const dispatch = useDispatch();
  const { items: courses, status } = useSelector((state) => state.courses);

  useEffect(() => {
    dispatch(fetchCourses());
  }, [dispatch]);

  return (
    <div className="container mt-4">
      <h2>Available Courses</h2>
      {status === "loading" && <p>Loading...</p>}
      <div className="row">
        {courses.map((course) => (
          <div className="col-md-4" key={course.id}>
            <CourseCard course={course} />
          </div>
        ))}
      </div>
    </div>
  );
};
