create table note (
  id uuid primary key default gen_random_uuid(),
  title text not null,
  content text not null default ''
);
