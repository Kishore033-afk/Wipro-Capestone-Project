import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";

const CourseDetail = () => {
  const { courseId } = useParams();
  const course = useSelector((state) =>
    state.courses.items.find((c) => c.id === Number(courseId))
  );

  if (!course) return <div>Course not found</div>;

  return (
    <div className="container mt-4">
      <h2>{course.title}</h2>
      <p>{course.description}</p>
      <h3>Lessons</h3>
      <div className="list-group">
        {course.lessons?.map((lesson) => (
          <div key={lesson.id} className="list-group-item">
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
        ))}
      </div>
    </div>
  );
};

export default CourseDetail;
