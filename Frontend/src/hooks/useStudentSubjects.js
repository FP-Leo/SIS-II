import { useSuspenseQuery } from "@tanstack/react-query";
import { _studentSubjects } from "@/_mock/data";
import { SUBJECTS_API_KEY } from "@/constants/apiConstants";

export const useStudentSubjects = () => {
  const getStudentSubjects = useSuspenseQuery({
    queryFn: () =>
      new Promise((resolve) => {
        setTimeout(() => {
          resolve(_studentSubjects);
        }, 2000);
      }),
    queryKey: [SUBJECTS_API_KEY],
  });

  return { getStudentSubjects };
};
