// src/components/QuizComponent.jsx
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchQuizzes, submitQuizAttempt } from "../store/slices/quizSlice";

const QuizComponent = ({ courseId }) => {
  const dispatch = useDispatch();
  const { quizzes, status } = useSelector((state) => state.quizzes);
  const { user } = useSelector((state) => state.auth);

  useEffect(() => {
    dispatch(fetchQuizzes(courseId));
  }, [dispatch, courseId]);

  const handleSubmit = (quizId, answers) => {
    const attemptData = {
      userId: user.id,
      quizId,
      answers,
      attemptDate: new Date().toISOString(),
    };
    dispatch(submitQuizAttempt(attemptData));
  };

  return (
    <div className="mt-4">
      <h3>Course Quizzes</h3>
      {status === "loading" && (
        <div className="spinner-border text-primary"></div>
      )}

      {quizzes.map((quiz) => (
        <div key={quiz.id} className="card mb-4">
          <div className="card-body">
            <h5 className="card-title">{quiz.title}</h5>

            {quiz.questions?.map((question, qIndex) => (
              <div key={question.id} className="mb-3">
                <p>
                  <strong>Question {qIndex + 1}:</strong> {question.text}
                </p>
                <div className="ms-3">
                  {["A", "B", "C", "D"].map((option) => (
                    <div key={option} className="form-check">
                      <input
                        className="form-check-input"
                        type="radio"
                        name={`question-${question.id}`}
                        id={`q${question.id}-${option}`}
                      />
                      <label
                        className="form-check-label"
                        htmlFor={`q${question.id}-${option}`}
                      >
                        {option}: {question[`option${option}`]}
                      </label>
                    </div>
                  ))}
                </div>
              </div>
            ))}

            <button
              className="btn btn-primary mt-3"
              onClick={() => handleSubmit(quiz.id, {})}
            >
              Submit Quiz
            </button>
          </div>
        </div>
      ))}
    </div>
  );
};

export default QuizComponent;
