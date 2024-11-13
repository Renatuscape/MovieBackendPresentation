create table Movie
(
    Id     INTEGER not null
        constraint PK_Movie
            primary key autoincrement,
    Title  TEXT    not null,
    Genre  TEXT    not null,
    ImgUrl TEXT    not null
);

create table User
(
    Id       INTEGER not null
        constraint PK_User
            primary key autoincrement,
    Username TEXT    not null,
    Email    TEXT    not null,
    Password TEXT    not null,
    Salt     TEXT    not null
);

create table Favourites
(
    Id      INTEGER not null
        constraint PK_Favourites
            primary key autoincrement,
    UserId  INTEGER not null
        constraint FK_Favourites_User_UserId
            references User
            on delete cascade,
    MovieId INTEGER not null
        constraint FK_Favourites_Movie_MovieId
            references Movie
            on delete cascade
);

create index IX_Favourites_MovieId
    on Favourites (MovieId);

create index IX_Favourites_UserId
    on Favourites (UserId);


