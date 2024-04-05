/* Module Script */
var RyanJagdfeld = RyanJagdfeld || {};

RyanJagdfeld.GitHubCard = {
    init: function (element, options) {
        var self = this;

        self.element = element;
        self.options = options;

        self.render();
    },
    render: function () {
        var self = this;

        var card = document.createElement('div');
        card.className = 'github-card';
        card.innerHTML = '<div class="github-card__header"><div class="github-card__header__avatar"><img src="' + self.options.avatar + '" alt="' + self.options.username + '"></div><div class="github-card__header__username">' + self.options.username + '</div></div><div class="github-card__body"><div class="github-card__body__repo"><div class="github-card__body__repo__name">' + self.options.repo + '</div><div class="github-card__body__repo__description">' + self.options.description + '</div></div><div class="github-card__body__stats"><div class="github-card__body__stats__stat"><span>' + self.options.stars + '</span> Stars</div><div class="github-card__body__stats__stat"><span>' + self.options.forks + '</span> Forks</div></div></div><div class="github-card__footer"><a href="' + self.options.url + '" target="_blank">View on GitHub</a></div>';

        self.element.appendChild(card);
    }
};