import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { fetchEnrollments } from "../store/slices/enrollmentSlice";

export const Dashboard = () => {
  const dispatch = useDispatch();
  const { user } = useSelector((state) => state.auth);
  const { items: enrollments, status } = useSelector(
    (state) => state.enrollments
  );

  useEffect(() => {
    if (user) {
      dispatch(fetchEnrollments(user.id));
    }
  }, [dispatch, user]);

  return (
    <div className="container mt-4">
      <h2>Welcome, {user?.fullName}</h2>
      <h4>Your Enrollments</h4>
      {status === "loading" && <p>Loading enrollments...</p>}
      {enrollments.length === 0 && status !== "loading" ? (
        <p>You're not enrolled in any courses yet.</p>
      ) : (
        enrollments.map((enrollment) => (
          <div key={enrollment.id} className="card mb-3">
            <div className="card-body">
              <h5>{enrollment.course.title}</h5>
              <div className="progress">
                <div
                  className="progress-bar"
                  role="progressbar"
                  style={{ width: `${enrollment.progress}%` }}
                >
                  {enrollment.progress}%
                </div>
              </div>
            </div>
          </div>
        ))
      )}
    </div>
  );
};
