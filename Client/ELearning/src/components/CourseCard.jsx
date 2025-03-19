import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export const CourseCard = ({ course }) => {
  return (
    <div className="card mb-3">
      <div className="card-body">
        <h5 className="card-title">{course.title}</h5>
        <p className="card-text">{course.description}</p>
        <div className="d-flex justify-content-between">
          <Button as={Link} to={`/courses/${course.id}`} variant="primary">
            View Details
          </Button>
        </div>
      </div>
    </div>
  );
};
