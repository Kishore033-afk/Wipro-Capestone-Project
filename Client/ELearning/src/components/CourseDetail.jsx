// src/pages/CourseDetail.jsx
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { Quiz } from "../components/Quiz";

export const CourseDetail = () => {
  const { courseId } = useParams();
  const course = useSelector((state) =>
    state.courses.items.find((c) => c.id === Number(courseId))
  );

  if (!course) return <div>Course not found</div>;

  return (
    <div className="container mt-4">
      <h2>{course.title}</h2>
      <p className="lead">{course.description}</p>

      <div className="row mt-4">
        <div className="col-md-8">
          <h3>Lessons</h3>
          {course.lessons.map((lesson) => (
            <div key={lesson.id} className="card mb-3">
              <div className="card-body">
                <h5>{lesson.title}</h5>
                <p>{lesson.content}</p>
                {lesson.videoUrl && (
                  <div className="ratio ratio-16x9">
                    <iframe
                      src={lesson.videoUrl}
                      title={lesson.title}
                      allowFullScreen
                    ></iframe>
                  </div>
                )}
              </div>
            </div>
          ))}
        </div>

        <div className="col-md-4">
          <Quiz courseId={courseId} />
        </div>
      </div>
    </div>
  );
};
